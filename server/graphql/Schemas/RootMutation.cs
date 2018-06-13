using GraphQL.Types;
using MessageBoard.GraphQL.Model;

namespace MessageBoard.GraphQL.Schemas
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation(IRepository repository)
        {
            Name = "RootMutation";

            Field<VoteType>(
                name: "addVote",
                description: "Add a vote to a message for some ranking",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<VoteInputType>> { Name = "vote" }
                ),
                resolve: context => repository.AddVote(context.GetArgument<AddVoteModel>("vote"))
            );

            Field<MessageType>(
                name: "createMessage",
                description: "Submit a new message",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MessageInputType>> { Name = "message" }
                ),
                resolve: context => repository.CreateMessage(context.GetArgument<CreateMessageModel>("message"))
            );
        }
    }
}