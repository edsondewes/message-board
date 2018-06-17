using System.Collections.Generic;
using GraphQL.Types;
using MessageBoard.GraphQL.Model;

namespace MessageBoard.GraphQL.Schemas
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(IRepository repository)
        {
            Name = "RootQuery";

            FieldAsync<ListGraphType<MessageType>, IEnumerable<Message>>(
                name: "messages",
                description: "Message paginated list",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "from", Description = "Message ID to start the list from" }
                ),
                resolve: context => repository.PaginateMessages(context.GetArgument<int>("from"))
            );

            FieldAsync<ListGraphType<MessageRankingType>, IEnumerable<MessageRanking>>(
                name: "ranking",
                description: "Ranking of messages based on a voting option",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "optionName", Description = "Type of vote" }
                ),
                resolve: context => repository.ListMessagesByRanking(context.GetArgument<string>("optionName"))
            );
        }
    }
}