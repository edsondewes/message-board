using GraphQL.Types;
using MessageBoard.GraphQL.Model;

namespace MessageBoard.GraphQL.Schemas
{
    public class MessageType : ObjectGraphType<Message>
    {
        public MessageType(IRepository repository)
        {
            Name = "Message";

            Field(h => h.Id).Description("Id of the message");
            Field(h => h.Created).Description("Date the message was created");
            Field(h => h.Text).Description("Message content");

            Field<ListGraphType<VoteType>>(
                name: "votes",
                description: "List os votes for this message",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "optionName", Description = "Type of vote" }
                ),
                resolve: context => repository.ListVotes(context.Source.Id.ToString(), context.GetArgument<string>("optionName"))
            );
        }
    }
}