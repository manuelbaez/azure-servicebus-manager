using Microsoft.Extensions.DependencyInjection;
using AzureServiceBusManager.Services.Abstraction;
using AzureServiceBusManager.Enums;

namespace AzureServiceBusManager.DependencyInjection.Abstractions
{
    public interface IConnectionBuilder<T> where T : class, IServiceBusMessagingService
    {
        IServiceCollection Services { get; set; }
        void SetConnectionInstance(string connectionString);
    }
}
