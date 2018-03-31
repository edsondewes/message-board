using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MessageBoard.Voting.Core.Queries
{
    public class VoteCountHandler : IRequestHandler<VoteCountQuery, IEnumerable<Vote>>
    {
        private IVoteRepository _repository;

        public VoteCountHandler(IVoteRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Vote>> Handle(VoteCountQuery request, CancellationToken cancellationToken)
        {
            return _repository.List(request.SubjectId);
        }
    }
}
