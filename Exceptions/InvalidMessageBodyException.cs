using AzureServiceBusManager.Constants;
using System;

namespace MessagingManager.AzureServiceBus.Exceptions
{
    public class InvalidMessageBodyException : Exception
    {
        public InvalidMessageBodyException() : base(ErrorMessages.InvalidMessageBody)
        {

        }
    }
}
