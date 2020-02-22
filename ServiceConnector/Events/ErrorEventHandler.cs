using Microsoft.Azure.ServiceBus;

namespace AzureServiceBusManager.ServiceConnector.Events
{
    public delegate void ErrorEventHandler(object sender, ExceptionReceivedEventArgs e);

}
