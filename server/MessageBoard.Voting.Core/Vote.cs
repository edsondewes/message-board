namespace MessageBoard.Voting.Core
{
    public class Vote
    {
        public uint Count { get; set; }
        public string OptionName { get; set; }
        public string SubjectId { get; set; }
    }
}
