using AzureServiceBusManager.Enums;
using AzureServiceBusManager.Models;
using AzureServiceBusManager.ServiceConnector.Abstractions;
using AzureServiceBusManager.Services.Abstraction;
using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;

namespace AzureServiceBusManager.Services
{
    public abstract class ServiceBusMessagingService : IServiceBusMessagingService
    {
        public IServiceBusConnection Connection { get; }
        public Dictionary<string, Func<object>> Queues { get; set; }

        public ServiceBusMessagingService(IServiceBusConnection connection)
        {
            Connection = connection;
        }

        public void AddMessageConsumer(MessageListenerProperties properties)
        {
            Connection.AddListener(properties);
        }

        public void PublishMessage(string destination, ServiceBusEntityType entityType, Message message)
        {
            Connection.PublishMessage(destination, entityType, message);
        }

    }
}
