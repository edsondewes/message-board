using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MessageBoard.Ranking.Core.Queries
{
    public class TopRankingHandler : IRequestHandler<TopRankingQuery, IEnumerable<VoteCount>>
    {
        private IRankingRepository _repository;

        public TopRankingHandler(IRankingRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<VoteCount>> Handle(TopRankingQuery request, CancellationToken cancellationToken)
        {
            return _repository.List(request.OptionName, request.Length);
        }
    }
}
