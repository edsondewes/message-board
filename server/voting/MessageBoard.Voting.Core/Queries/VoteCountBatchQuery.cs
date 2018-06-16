using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace MessageBoard.Voting.Core.Queries
{
    public class VoteCountBatchQuery : IRequest<IEnumerable<Vote>>
    {
        public string[] SubjectIds { get; }

        public VoteCountBatchQuery(IEnumerable<string> subjectIds)
        {
            if (subjectIds == null)
                throw new ArgumentNullException(nameof(subjectIds));

            SubjectIds = subjectIds.ToArray();
        }
    }
}
