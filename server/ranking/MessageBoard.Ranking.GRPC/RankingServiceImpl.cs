using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using MessageBoard.Ranking.Core;
using MessageBoard.Ranking.Core.Queries;
using Microsoft.Extensions.DependencyInjection;
using static MessageBoard.Ranking.GRPC.RankingResponse.Types;

namespace MessageBoard.Ranking.GRPC
{
    public class RankingServiceImpl : RankingService.RankingServiceBase
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public RankingServiceImpl(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public override async Task<RankingResponse> List(ListRequest request, ServerCallContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var ranking = await mediator.Send(new TopRankingQuery(request.OptionName));

                var response = new RankingResponse();
                response.Votes.AddRange(ranking.Select(ToResponse));
                return response;
            }
        }

        private VoteCountResponse ToResponse(VoteCount voteCount) => new VoteCountResponse
        {
            Count = voteCount.Count,
            SubjectId = voteCount.SubjectId
        };
    }
}