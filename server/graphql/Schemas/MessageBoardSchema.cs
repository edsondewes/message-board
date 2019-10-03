using System;
using GraphQL.Types;
using GraphQL.Utilities;

namespace MessageBoard.GraphQL.Schemas
{
    public class MessageBoardSchema : Schema
    {
        public MessageBoardSchema(IServiceProvider provider)
            : base(provider)
        {
            Mutation = provider.GetRequiredService<RootMutation>();
            Query = provider.GetRequiredService<RootQuery>();
        }
    }
}