using GraphQL;
using GraphQL.Types;

namespace MessageBoard.GraphQL.Schemas
{
    public class MessageBoardSchema : Schema
    {
        public MessageBoardSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Mutation = resolver.Resolve<RootMutation>();
            Query = resolver.Resolve<RootQuery>();
        }
    }
}