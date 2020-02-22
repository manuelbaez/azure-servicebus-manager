using AzureServiceBusManager.Constants;
using System;

namespace MessagingManager.AzureServiceBus.Exceptions
{
    public class NoContentTypeException : Exception
    {
        public NoContentTypeException() : base(ErrorMessages.NoContentType)
        {

        }
    }
}
