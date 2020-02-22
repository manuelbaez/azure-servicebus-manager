using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using System;
using System.Threading;

namespace AzureServiceBusManager.ServiceConnector.Events
{
    public delegate void MessageEventHandler(object sender, MessageEventArgs e);
    public class MessageEventArgs : EventArgs
    {
        public Message Message { get; set; }
        public CancellationToken CancellationToken { get; set; }
        public IReceiverClient Client { get; set; }
    }
}
