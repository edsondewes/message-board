using System;
using MediatR;

namespace MessageBoard.Voting.Core.Events
{
    public class VoteCreated : INotification
    {
        public uint Count { get; set; }
        public string OptionName { get; set; }
        public string SubjectId { get; set; }

        public static VoteCreated From(Vote obj) => new VoteCreated
        {
            Count = obj.Count,
            OptionName = obj.OptionName,
            SubjectId = obj.SubjectId
        };
    }
}
