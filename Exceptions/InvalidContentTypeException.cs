using AzureServiceBusManager.Constants;
using System;

namespace AzureServiceBusManager.AzureServiceBus.Exceptions
{
    public class InvalidContentTypeException : Exception
    {
        public InvalidContentTypeException() : base(ErrorMessages.InvalidContentType)
        {

        }
    }
}
