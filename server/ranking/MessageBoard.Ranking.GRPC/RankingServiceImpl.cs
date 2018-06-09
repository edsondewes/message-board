using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using MessageBoard.Ranking.Core.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBoard.Ranking.GRPC
{
    public class RankingServiceImpl : RankingService.RankingServiceBase
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public RankingServiceImpl(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public override async Task List(ListRequest request, IServerStreamWriter<RankingResponse> responseStream, ServerCallContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var ranking = await mediator.Send(new TopRankingQuery(request.OptionName));

                foreach (var item in ranking)
                {
                    await responseStream.WriteAsync(new RankingResponse
                    {
                        SubjectId = item.SubjectId,
                        Count = item.Count
                    });
                }
            }
        }
    }
}