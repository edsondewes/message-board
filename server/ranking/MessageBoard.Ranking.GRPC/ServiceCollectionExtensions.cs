using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessageBoard.Ranking.GRPC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGRPCServer(this IServiceCollection services)
        {
            services.AddSingleton<RankingServiceImpl>();
            services.AddSingleton<IHostedService, BackgroundServerGRPC>();

            return services;
        }
    }
}
