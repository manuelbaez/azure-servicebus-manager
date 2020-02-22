using AzureServiceBusManager.DependencyInjection.Abstractions;
using AzureServiceBusManager.ServiceConnector;
using AzureServiceBusManager.ServiceConnector.Abstractions;
using AzureServiceBusManager.Services.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace AzureServiceBusManager.DependencyInjection
{
    class AzureConnectionBuilder<T> : IConnectionBuilder<T> where T : class, IServiceBusMessagingService
    {
        public IServiceCollection Services { get; set; }

        public void SetConnectionInstance(string connectionString)
        {
            var connector = new AzureSerivceBusConnector<T>(connectionString);
            Services.AddSingleton<IServiceBusConnection<T>>(_ => connector);
        }
    }
}
