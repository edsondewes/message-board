using Grpc.Core;
using MessageBoard.GraphQL.GRPC;
using MessageBoard.GraphQL.Model;
using MessageBoard.Messaging.GRPC;
using MessageBoard.Ranking.GRPC;
using MessageBoard.Voting.GRPC;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GrpcServiceCollectionExtensions
    {
        public static IServiceCollection AddGRPC(this IServiceCollection services)
        {
            services.AddSingleton<MessageService.MessageServiceClient>((provider) =>
            {
                var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
                return new MessageService.MessageServiceClient(channel);
            });

            services.AddSingleton<RankingService.RankingServiceClient>((provider) =>
            {
                var channel = new Channel("127.0.0.1:50053", ChannelCredentials.Insecure);
                return new RankingService.RankingServiceClient(channel);
            });

            services.AddSingleton<VoteService.VoteServiceClient>((provider) =>
            {
                var channel = new Channel("127.0.0.1:50052", ChannelCredentials.Insecure);
                return new VoteService.VoteServiceClient(channel);
            });

            services.AddSingleton<IRepository, RepositoryGrpc>();

            return services;
        }
    }
}