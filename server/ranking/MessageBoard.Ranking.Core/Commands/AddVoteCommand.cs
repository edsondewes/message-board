using System;
using MediatR;

namespace MessageBoard.Ranking.Core.Commands
{
    public class AddVoteCommand : IRequest
    {
        public string OptionName { get; }
        public string SubjectId { get; }

        public AddVoteCommand(string subjectId, string optionName)
        {
            if (string.IsNullOrEmpty(subjectId))
            {
                throw new ArgumentNullException(nameof(subjectId));
            }

            if (string.IsNullOrEmpty(optionName))
            {
                throw new ArgumentNullException(nameof(optionName));
            }

            OptionName = optionName;
            SubjectId = subjectId;
        }
    }
}
