using Microsoft.Azure.ServiceBus;
using System.Net.Mime;
using System.Threading;

namespace AzureServiceBusManager.ServiceConnector.Abstractions
{

    public interface IMessageHandler<TDeliveryTag>
    {
        void AcknowledgeMessage();
    }
}
