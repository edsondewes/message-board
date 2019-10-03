namespace MessageBoard.Ranking.Core
{
    public class VoteCount
    {
        public uint Count { get; set; }
        public string SubjectId { get; set; }

        public VoteCount(string subjectId, uint count)
        {
            SubjectId = subjectId;
            Count = count;
        }
    }
}