using System;
using GraphQL.DataLoader;
using GraphQL.Types;
using MessageBoard.GraphQL.Model;

namespace MessageBoard.GraphQL.Schemas
{
    public class MessageRankingType : ObjectGraphType<MessageBoard.GraphQL.Model.MessageRanking>
    {
        public MessageRankingType(IDataLoaderContextAccessor accessor, IRepository repository)
        {
            Name = "MessageRanking";

            Field(h => h.VoteCount, type: typeof(IntGraphType))
                .Description("Count of votes for this ranking");

            FieldAsync<MessageType, Message>(
                name: "message",
                description: "Message data",
                resolve: context =>
                {
                    var loader = accessor.Context.GetOrAddBatchLoader<long, Message>("GeMessagesById", repository.ListMessages);
                    return loader.LoadAsync(Convert.ToInt64(context.Source.SubjectId));
                }
            );
        }
    }
}