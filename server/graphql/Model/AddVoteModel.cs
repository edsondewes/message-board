namespace MessageBoard.GraphQL.Model
{
    public class AddVoteModel
    {
        public string OptionName { get; set; } = null!;
        public string SubjectId { get; set; } = null!;
    }
}