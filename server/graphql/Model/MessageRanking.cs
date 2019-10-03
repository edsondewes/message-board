namespace MessageBoard.GraphQL.Model
{
    public class MessageRanking
    {
        public string SubjectId { get; set; }
        public uint VoteCount { get; set; }

        public MessageRanking(string subjectId, uint voteCount)
        {
            SubjectId = subjectId;
            VoteCount = voteCount;
        }
    }
}