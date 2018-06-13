using GraphQL.Types;
using MessageBoard.GraphQL.Model;

namespace MessageBoard.GraphQL.Schemas
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(IRepository repository)
        {
            Name = "RootQuery";

            Field<ListGraphType<MessageType>>(
                name: "messages",
                description: "Message paginated list",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "from", Description = "Message ID to start the list from" }
                ),
                resolve: context => repository.ListMessages(context.GetArgument<int>("from"))
            );

            Field<ListGraphType<MessageRankingType>>(
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