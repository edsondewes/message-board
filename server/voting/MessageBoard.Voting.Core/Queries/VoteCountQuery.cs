using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace MessageBoard.Voting.Core.Queries
{
    public class VoteCountQuery : IRequest<IEnumerable<Vote>>
    {
        public List<string>? OptionNames { get; }
        public string SubjectId { get; }

        public VoteCountQuery(string subjectId, IEnumerable<string>? optionNames = null)
        {
            if (string.IsNullOrEmpty(subjectId))
            {
                throw new ArgumentNullException(nameof(subjectId));
            }

            if (optionNames != null)
            {
                OptionNames = optionNames.ToList();
            }

            SubjectId = subjectId;
        }
    }
}
