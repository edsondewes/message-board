using Grpc.Core;
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

            services.AddSingleton<MessageService.MessageServiceClient>((provider) =>
            {
                var channel = new Channel(messagingTarget, ChannelCredentials.Insecure);
                return new MessageService.MessageServiceClient(channel);
            });

            services.AddSingleton<RankingService.RankingServiceClient>((provider) =>
            {
                var channel = new Channel(rankingTarget, ChannelCredentials.Insecure);
                return new RankingService.RankingServiceClient(channel);
            });

            services.AddSingleton<VoteService.VoteServiceClient>((provider) =>
            {
                var channel = new Channel(votingTarget, ChannelCredentials.Insecure);
                return new VoteService.VoteServiceClient(channel);
            });

            services.AddSingleton<IRepository, RepositoryGrpc>();

            return services;
        }
    }
}