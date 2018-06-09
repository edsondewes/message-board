using System;
using MessageBoard.Voting.Core;
using MessageBoard.Voting.Nats;
using NATS.Client;

namespace Microsoft.Extensions.DependencyInjection
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
