using System.Collections.Generic;
using GraphQL.DataLoader;
using GraphQL.Types;
using MessageBoard.GraphQL.Model;

namespace MessageBoard.GraphQL.Schemas
{
    public class MessageType : ObjectGraphType<Message>
    {
        public MessageType(IDataLoaderContextAccessor accessor, IRepository repository)
        {
            Name = "Message";

            Field(h => h.Id).Description("Id of the message");
            Field(h => h.Created).Description("Date the message was created");
            Field(h => h.Text).Description("Message content");

            FieldAsync<ListGraphType<VoteType>, IEnumerable<Vote>>(
                name: "votes",
                description: "List os votes for this message",
                arguments: new QueryArguments(
                    new QueryArgument<ListGraphType<StringGraphType>> { Name = "optionName", Description = "Type of vote" }
                ),
                resolve: context =>
                {
                    var fetchFunc = repository.ListVotes(context.GetArgument<IEnumerable<string>>("optionName"));
                    var loader = accessor.Context.GetOrAddBatchLoader<string, IEnumerable<Vote>>("GetVotesBySubjectId", fetchFunc);

                    return loader.LoadAsync(context.Source.Id.ToString());
                }
            );
        }
    }
}