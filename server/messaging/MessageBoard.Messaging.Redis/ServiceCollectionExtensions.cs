using MessageBoard.Messaging.Core;
using MessageBoard.Messaging.Redis;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection services, string host)
        {
            services.AddSingleton<IMessageRepository>(provider => new MessageRepositoryRedis(host));
            return services;
        }
    }
}