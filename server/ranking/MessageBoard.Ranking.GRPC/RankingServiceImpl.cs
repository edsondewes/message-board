using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using MessageBoard.Ranking.Core;
using MessageBoard.Ranking.Core.Queries;
using static MessageBoard.Ranking.GRPC.RankingResponse.Types;

namespace MessageBoard.Ranking.GRPC
{
    public class RankingServiceImpl : RankingService.RankingServiceBase
    {
        private readonly IMediator _mediator;

        public RankingServiceImpl(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<RankingResponse> List(ListRequest request, ServerCallContext context)
        {
            var ranking = await _mediator.Send(new TopRankingQuery(request.OptionName));

            var response = new RankingResponse();
            response.Votes.AddRange(ranking.Select(ToResponse));
            return response;
        }

        private VoteCountResponse ToResponse(VoteCount voteCount) => new VoteCountResponse
        {
            Count = voteCount.Count,
            SubjectId = voteCount.SubjectId
        };
    }
}