using AzureServiceBusManager.Enums;

namespace MessagingManager.AzureServiceBus.Connector
{
    class AzureConnectionInfo
    {
        public string ConnectionString { get; set; }
        public ServiceBusEntityType EntityType { get; set; }
        public int OperationTimeoutSeconds { get; set; }
    }
}
