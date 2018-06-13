using System;
using System.Threading.Tasks;
using GraphQL.Types;
using MessageBoard.GraphQL.Model;

namespace MessageBoard.GraphQL.Schemas
{
    public class MessageRankingType : ObjectGraphType<MessageBoard.GraphQL.Model.MessageRanking>
    {
        public MessageRankingType(IRepository repository)
        {
            Name = "MessageRanking";

            Field(h => h.VoteCount, type: typeof(IntGraphType))
                .Description("Count of votes for this ranking");

            Field<MessageType>(
                name: "message",
                description: "Message data",
                resolve: context => repository.GetMessage(Convert.ToInt64(context.Source.SubjectId))
            );
        }
    }
}