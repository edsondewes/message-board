using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessageBoard.Messaging.GRPC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGRPCServer(this IServiceCollection services)
        {
            services.AddSingleton<MessageServiceImpl>();
            services.AddSingleton<IHostedService, BackgroundServerGRPC>();

            return services;
        }
    }
}
