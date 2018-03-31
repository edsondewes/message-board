using MessageBoard.Voting.Core;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBoard.Voting.Redis
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection services, string host)
        {
            services.AddSingleton<IVoteRepository>(provider => new VoteRepositoryRedis(host));
            return services;
        }
    }
}
