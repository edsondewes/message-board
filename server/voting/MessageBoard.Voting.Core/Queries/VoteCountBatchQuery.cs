using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace MessageBoard.Voting.Core.Queries
{
    public class VoteCountBatchQuery : IRequest<IEnumerable<Vote>>
    {
        public List<string>? OptionNames { get; }
        public List<string> SubjectIds { get; }

        public VoteCountBatchQuery(IEnumerable<string> subjectIds, IEnumerable<string>? optionNames = null)
        {
            if (subjectIds is null)
            {
                throw new ArgumentNullException(nameof(subjectIds));
            }

            if (optionNames != null)
            {
                OptionNames = optionNames.ToList();
            }

            SubjectIds = subjectIds.ToList();
        }
    }
}
