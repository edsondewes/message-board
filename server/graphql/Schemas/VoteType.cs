using GraphQL.Types;
using MessageBoard.GraphQL.Model;

namespace MessageBoard.GraphQL.Schemas
{
    public class VoteType : ObjectGraphType<Vote>
    {
        public VoteType()
        {
            Name = "Vote";

            Field(h => h.Count, type: typeof(IntGraphType))
                .Description("Number of votes this entity received");

            Field(h => h.OptionName)
                .Description("Type of vote");
        }
    }
}