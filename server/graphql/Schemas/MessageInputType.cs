using GraphQL.Types;

namespace MessageBoard.GraphQL.Schemas
{
    public class MessageInputType : InputObjectGraphType
    {
        public MessageInputType()
        {
            Name = "MessageInput";

            Field<NonNullGraphType<StringGraphType>>(
                name: "text",
                description: "Content of the message"
            );
        }
    }
}