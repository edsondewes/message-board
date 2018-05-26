using System;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace MessageBoard.Voting.Redis
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection services, string host)
        {
            if (string.IsNullOrEmpty(host))
                throw new ArgumentNullException(nameof(host));

            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(host));
            services.AddScoped<IDatabase>(provider => provider.GetRequiredService<IConnectionMultiplexer>().GetDatabase());

            return services;
        }
    }
}
