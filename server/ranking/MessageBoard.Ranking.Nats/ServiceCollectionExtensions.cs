
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessageBoard.Ranking.Nats
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNats(this IServiceCollection services, string url)
        {
            services.AddSingleton<IHostedService, SubscriptionsServiceNats>(provider =>
                new SubscriptionsServiceNats(
                    provider.GetRequiredService<IServiceScopeFactory>(),
                    url));

            return services;
        }
    }
}
