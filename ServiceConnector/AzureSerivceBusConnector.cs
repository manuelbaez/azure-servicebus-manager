using AzureServiceBusManager.Enums;
using AzureServiceBusManager.Exceptions;
using AzureServiceBusManager.Models;
using AzureServiceBusManager.ServiceConnector.Abstractions;
using AzureServiceBusManager.Services.Abstraction;
using MessagingManager.AzureServiceBus.Connector;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using System;
using System.Collections.Concurrent;

namespace AzureServiceBusManager.ServiceConnector
{
    class AzureSerivceBusConnector<T> : IServiceBusConnection<T, AzureConnectionInfo> where T : class, IServiceBusMessagingService
    {
        public AzureConnectionInfo ConnectionChannel { get; }

        object IServiceBusConnection.ConnectionChannel => ConnectionChannel;

        private ConcurrentDictionary<Guid, IClientEntity> openConnections = new ConcurrentDictionary<Guid, IClientEntity>();

        public AzureSerivceBusConnector(string connectionString, int operationTimeoutSeconds = 30)
        {
            ConnectionChannel = new AzureConnectionInfo { ConnectionString = connectionString, OperationTimeoutSeconds = operationTimeoutSeconds };
        }

        public Guid AddListener(MessageListenerProperties properties)
        {
            var connection = OpenConnection(properties.ObjectName, properties.EntityType);

            var handler = new MessageHandler { Client = connection.client as IReceiverClient };
            handler.OnError += properties.OnError;
            handler.OnMessage += properties.OnMessage;
            var messageHandleOptions = new MessageHandlerOptions(handler.HandleError)
            {
                MaxConcurrentCalls = properties.MaxConcurrentCalls,
                AutoComplete = false
            };

            var client = connection.client as IReceiverClient;

            client.RegisterMessageHandler(handler.ProcessMessage, messageHandleOptions);

            return connection.id;
        }

        private (Guid id, IClientEntity client) OpenConnection(string objectName, ServiceBusEntityType entityType)
        {
            var connectionId = Guid.NewGuid();
            IClientEntity client = null;
            switch (entityType)
            {
                case ServiceBusEntityType.Queue:
                    client = new QueueClient(ConnectionChannel.ConnectionString, objectName);
                    break;
                case ServiceBusEntityType.Topic:
                    client = new TopicClient(ConnectionChannel.ConnectionString, objectName);
                    break;
                case ServiceBusEntityType.Subscription:
                    var names = objectName.Split('/');
                    client = new SubscriptionClient(ConnectionChannel.ConnectionString, names[0], names[1]);
                    break;
            }
            client.OperationTimeout = new TimeSpan(0, 0, ConnectionChannel.OperationTimeoutSeconds);
            if (client != null)
                openConnections.TryAdd(connectionId, client);
            else
                throw new InvalidEntityTypeException();
            return (connectionId, client);
        }
        private void CloseConnection(Guid id)
        {
            openConnections.TryGetValue(id, out var client);
            client.CloseAsync();
            openConnections.TryRemove(id, out var _client);
        }

        public void Dispose()
        {
            foreach (var connection in openConnections)
            {
                connection.Value.CloseAsync();
            }
        }

        public void PublishMessage(string destination, ServiceBusEntityType entityType, Message message)
        {
            var connection = OpenConnection(destination, entityType);

            if (connection.client is IQueueClient)
            {
                var client = connection.client as IQueueClient;
                client.SendAsync(message).GetAwaiter().GetResult();

            }
            if (connection.client is ITopicClient)
            {
                var client = connection.client as ITopicClient;
                client.SendAsync(message).GetAwaiter().GetResult();
            }
            CloseConnection(connection.id);
        }

    }
}
