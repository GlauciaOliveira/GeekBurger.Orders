﻿using AutoMapper;
using GeekBurger.Orders.Model;
using Microsoft.Azure.Management.ServiceBus.Fluent;
using Microsoft.Azure.ServiceBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeekBurger.Orders.Service
{
    public class OrderPaidService:IOrderPaidService 
    {
        private const string Topic = "OrderPaidTopic";
        private IConfiguration _configuration;
        private IMapper _mapper;
        private List<Message> _messages;
        private Task _lastTask;
        private IServiceBusNamespace _namespace;

        public void AddToMessageList(IEnumerable<EntityEntry<Order>> changes)
        {
            _messages.AddRange(changes
.Where(entity => entity.State != EntityState.Detached
        && entity.State != EntityState.Unchanged)
.Select(GetMessage).ToList());
        }

        public Message GetMessage(EntityEntry<Order> entity)
        {
            var orderChanged = Mapper.Map<Order>(entity);
            var orderChangedSerialized = JsonConvert.SerializeObject(orderChanged);
            var orderChangedByteArray = Encoding.UTF8.GetBytes(orderChangedSerialized);

            return new Message
            {
                Body = orderChangedByteArray,
                MessageId = Guid.NewGuid().ToString(),
                Label = orderChanged.OrderId.ToString()
            };
        }

        public async void SendMessagesAsync()
        {
            if (_lastTask != null && !_lastTask.IsCompleted)
                return;

            var config = _configuration.GetSection("serviceBus").Get<ServiceBusConfiguration>();
            var topicClient = new TopicClient(config.ConnectionString, Topic);

            _lastTask = SendAsync(topicClient);

            await _lastTask;

            var closeTask = topicClient.CloseAsync();
            await closeTask;
            HandleException(closeTask);
        }



        public async Task SendAsync(TopicClient topicClient)
        {
            int tries = 0;
            Message message;
            while (true)
            {
                if (_messages.Count <= 0)
                    break;

                lock (_messages)
                {
                    message = _messages.FirstOrDefault();
                }

                var sendTask = topicClient.SendAsync(message);
                await sendTask;
                var success = HandleException(sendTask);

                if (!success)
                    Thread.Sleep(10000 * (tries < 60 ? tries++ : tries));
                else
                    _messages.Remove(message);
            }
        }

        public bool HandleException(Task task)
        {
            if (task.Exception == null || task.Exception.InnerExceptions.Count == 0) return true;

            task.Exception.InnerExceptions.ToList().ForEach(innerException =>
            {
                Console.WriteLine($"Error in SendAsync task: {innerException.Message}. Details:{innerException.StackTrace} ");

                if (innerException is ServiceBusCommunicationException)
                    Console.WriteLine("Connection Problem with Host. Internet Connection can be down");
            });

            return false;
        }




    }
}
