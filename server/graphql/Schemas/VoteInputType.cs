using GraphQL.Types;

namespace MessageBoard.GraphQL.Schemas
{
    public class VoteInputType : InputObjectGraphType
    {
        public VoteInputType()
        {
            Name = "VoteInput";

            Field<NonNullGraphType<StringGraphType>>(
                name: "optionName",
                description: "Type os vote"
            );

            Field<NonNullGraphType<StringGraphType>>(
                name: "subjectId",
                description: "Id of entity you are voting for"
            );
        }
    }
}