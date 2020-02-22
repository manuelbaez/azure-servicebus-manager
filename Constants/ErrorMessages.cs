using System;
using System.Collections.Generic;
using System.Text;

namespace AzureServiceBusManager.Constants
{
    public struct ErrorMessages
    {
        public const string NoContentType = "No content type specified on message, message body can not be deserialized";
        public const string InvalidContentType = "Invalid content type specified on message, message body can not be deserialized";
        public const string InvalidMessageBody = "The specified message body is invalid, message body can not be deserialized";
        public const string InvalidEntityType = "The specified azure entity type is not valid or configured";
    }
}
