using MessageBoard.Voting.Core;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBoard.Voting.Nats
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNats(this IServiceCollection services, string url)
        {
            services.AddSingleton<IEventBus, EventBusNats>(provider => new EventBusNats(url));
            return services;
        }
    }
}
