using MediatR;

namespace MessageBoard.Voting.Core.Events
{
    public class VoteCreated : INotification
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

        public static VoteCreated From(Vote obj) => new VoteCreated(
            count: obj.Count,
            optionName: obj.OptionName,
            subjectId: obj.SubjectId
            );
    }
}
