
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NATS.Client;

namespace MessageBoard.Ranking.Nats
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
