using System;
using MessageBoard.Ranking.Nats;
using Microsoft.Extensions.Hosting;
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
            services.AddSingleton<IHostedService, SubscriptionsServiceNats>();

            return services;
        }
    }
}
