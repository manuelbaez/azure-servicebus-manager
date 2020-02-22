using AzureServiceBusManager.ServiceConnector.Events;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using System.Threading;
using System.Threading.Tasks;

namespace AzureServiceBusManager.ServiceConnector
{
    public class MessageHandler
    {
        public event MessageEventHandler OnMessage;
        public event ErrorEventHandler OnError;
        public IReceiverClient Client { get; set; }
        public Task ProcessMessage(Message message, CancellationToken token)
        {
            var eventArgs = new MessageEventArgs
            {
                Message = message,
                CancellationToken = token,
                Client = Client
            };
            OnMessage.Invoke(this, eventArgs);
            return Task.CompletedTask;
        }
        public Task HandleError(ExceptionReceivedEventArgs exceptionReceived)
        {
            OnError.Invoke(this, exceptionReceived);
            return Task.CompletedTask;
        }


    }
}
