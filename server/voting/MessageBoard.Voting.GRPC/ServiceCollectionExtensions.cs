using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessageBoard.Voting.GRPC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGRPCServer(this IServiceCollection services)
        {
            services.AddSingleton<VoteServiceImpl>();
            services.AddSingleton<IHostedService, BackgroundServerGRPC>();

            return services;
        }
    }
}
