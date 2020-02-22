using AzureServiceBusManager.Enums;
using AzureServiceBusManager.Models;
using AzureServiceBusManager.Services.Abstraction;
using Microsoft.Azure.ServiceBus;
using System;

namespace AzureServiceBusManager.ServiceConnector.Abstractions
{
    public interface IServiceBusConnection : IDisposable
    {
        object ConnectionChannel { get; }
        Guid AddListener(MessageListenerProperties properties);
        void PublishMessage(string destination, ServiceBusEntityType entityType, Message message);
    }
    public interface IServiceBusConnection<S> : IServiceBusConnection where S : class, IServiceBusMessagingService
    {
    }
    public interface IServiceBusConnection<S, TChannel> : IServiceBusConnection<S> where S : class, IServiceBusMessagingService
    {
        new TChannel ConnectionChannel { get; }
    }
}