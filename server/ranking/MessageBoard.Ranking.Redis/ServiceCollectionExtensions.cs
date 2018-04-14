using MessageBoard.Ranking.Core;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBoard.Ranking.Redis
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection services, string host)
        {
            services.AddSingleton<IRankingRepository>(provider => new RankingRepositoryRedis(host));
            return services;
        }
    }
}
