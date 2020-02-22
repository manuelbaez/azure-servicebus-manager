using AzureServiceBusManager.Enums;
using AzureServiceBusManager.ServiceConnector.Events;

namespace AzureServiceBusManager.Models
{
    public class MessageListenerProperties
    {
        public string ObjectName { get; set; }
        public ServiceBusEntityType EntityType { get; set; }
        public MessageEventHandler OnMessage { get; set; }
        public ErrorEventHandler OnError { get; set; }
        public int MaxConcurrentCalls { get; set; }
    }
}
