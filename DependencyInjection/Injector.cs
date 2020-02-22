using Microsoft.Extensions.DependencyInjection;
using AzureServiceBusManager.DependencyInjection.Abstractions;
using AzureServiceBusManager.Services.Abstraction;
using System;

namespace AzureServiceBusManager.DependencyInjection
{
    public static class Injector
    {
        public static void AddServiceBus<T>(this IServiceCollection services, Action<IConnectionBuilder<T>> connectionBuilder)
        where T : class, IServiceBusMessagingService
        {
            connectionBuilder.Invoke(new AzureConnectionBuilder<T> { Services = services });
            services.AddSingleton<T>();
        }
    }
}
