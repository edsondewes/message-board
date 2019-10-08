using Grpc.Net.Client;
using MessageBoard.GraphQL.GRPC;
using MessageBoard.GraphQL.Model;
using MessageBoard.Messaging.GRPC;
using MessageBoard.Ranking.GRPC;
using MessageBoard.Voting.GRPC;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GrpcServiceCollectionExtensions
    {
        public static IServiceCollection AddGRPC(this IServiceCollection services, IConfiguration configuration)
        {
            var targets = configuration.GetSection("GRPC");
            var messagingTarget = targets.GetValue<string>("MessagingTarget");
            var rankingTarget = targets.GetValue<string>("RankingTarget");
            var votingTarget = targets.GetValue<string>("VotingTarget");

            services.AddSingleton((provider) =>
            {
                var channel = GrpcChannel.ForAddress(messagingTarget);
                return new MessageService.MessageServiceClient(channel);
            });

            services.AddSingleton((provider) =>
            {
                var channel = GrpcChannel.ForAddress(rankingTarget);
                return new RankingService.RankingServiceClient(channel);
            });

            services.AddSingleton((provider) =>
            {
                var channel = GrpcChannel.ForAddress(votingTarget);
                return new VoteService.VoteServiceClient(channel);
            });

            services.AddSingleton<IRepository, RepositoryGrpc>();

            return services;
        }
    }
}