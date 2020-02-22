using AzureServiceBusManager.Enums;
using AzureServiceBusManager.Models;
using AzureServiceBusManager.ServiceConnector.Abstractions;
using Microsoft.Azure.ServiceBus;

namespace AzureServiceBusManager.Services.Abstraction
{
    public interface IServiceBusMessagingService
    {
        IServiceBusConnection Connection { get; }
        void AddMessageConsumer(MessageListenerProperties properties);
        void PublishMessage(string destination, ServiceBusEntityType entityType, Message message);
    }
}
