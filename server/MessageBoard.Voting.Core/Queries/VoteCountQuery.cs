using System;
using System.Collections.Generic;
using MediatR;

namespace MessageBoard.Voting.Core.Queries
{
    public class VoteCountQuery : IRequest<IEnumerable<Vote>>
    {
        public string SubjectId { get; }

        public VoteCountQuery(string subjectId)
        {
            if (string.IsNullOrEmpty(subjectId))
                throw new ArgumentNullException(nameof(subjectId));

            SubjectId = subjectId;
        }
    }
}
