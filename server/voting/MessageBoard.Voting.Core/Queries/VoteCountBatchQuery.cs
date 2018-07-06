using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace MessageBoard.Voting.Core.Queries
{
    public class VoteCountBatchQuery : IRequest<IEnumerable<Vote>>
    {
        public string[] OptionNames { get; }
        public string[] SubjectIds { get; }

        public VoteCountBatchQuery(IEnumerable<string> subjectIds, IEnumerable<string> optionNames = null)
        {
            if (subjectIds == null)
                throw new ArgumentNullException(nameof(subjectIds));

            if (optionNames != null)
                OptionNames = optionNames.ToArray();

            SubjectIds = subjectIds.ToArray();
        }
    }
}
