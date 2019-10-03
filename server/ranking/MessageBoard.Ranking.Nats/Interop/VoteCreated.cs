namespace MessageBoard.Ranking.Nats.Interop
{
    public class VoteCreated
    {
        public uint Count { get; set; }
        public string OptionName { get; set; }
        public string SubjectId { get; set; }

        public VoteCreated(string subjectId, string optionName, uint count)
        {
            SubjectId = subjectId;
            OptionName = optionName;
            Count = count;
        }

    }
}
