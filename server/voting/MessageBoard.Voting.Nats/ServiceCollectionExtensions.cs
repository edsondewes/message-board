using System;
using MessageBoard.Voting.Core;
using Microsoft.Extensions.DependencyInjection;
using NATS.Client;

namespace MessageBoard.Voting.Nats
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNats(this IServiceCollection services, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            services.AddSingleton<IConnection>(new ConnectionFactory().CreateConnection(url));
            services.AddSingleton<IEventBus, EventBusNats>();

            return services;
        }
    }
}
