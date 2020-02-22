using AzureServiceBusManager.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureServiceBusManager.Exceptions
{
    public class InvalidEntityTypeException : Exception
    {
        public InvalidEntityTypeException() : base(ErrorMessages.InvalidEntityType)
        {

        }
    }
}
