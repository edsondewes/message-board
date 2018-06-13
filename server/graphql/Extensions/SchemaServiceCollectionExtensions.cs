using GraphQL.Types;
using MessageBoard.GraphQL.Schemas;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SchemaServiceCollectionExtensions
    {
        public static IServiceCollection AddMessageBoardSchema(this IServiceCollection services)
        {
            services.AddSingleton<ISchema, MessageBoardSchema>();
            services.AddSingleton<RootMutation>();
            services.AddSingleton<RootQuery>();
            services.AddSingleton<MessageInputType>();
            services.AddSingleton<MessageRankingType>();
            services.AddSingleton<MessageType>();
            services.AddSingleton<VoteInputType>();
            services.AddSingleton<VoteType>();

            return services;
        }
    }
}