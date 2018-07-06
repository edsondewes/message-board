using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using MessageBoard.Voting.Core;
using MessageBoard.Voting.Core.Commands;
using MessageBoard.Voting.Core.Events;
using MessageBoard.Voting.Core.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBoard.Voting.GRPC
{
    public class VoteServiceImpl : VoteService.VoteServiceBase
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public VoteServiceImpl(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public override async Task<VoteResponse> Add(AddRequest request, ServerCallContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var vote = await mediator.Send(new AddVoteCommand(request.SubjectId, request.OptionName));

                return new VoteResponse
                {
                    Count = vote.Count,
                    OptionName = vote.OptionName,
                };
            }
        }

        public override async Task<LoadResponse> Load(LoadRequest request, ServerCallContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var votes = await mediator.Send(new VoteCountQuery(request.SubjectId));

                var response = new LoadResponse();
                response.Votes.AddRange(votes.Select(ToResponse));
                return response;
            }
        }

        public override async Task<LoadBatchResponse> LoadBatch(LoadBatchRequest request, ServerCallContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var votes = await mediator.Send(new VoteCountBatchQuery(request.SubjectId, request.OptionNames));

                var batchResponse = new LoadBatchResponse();
                foreach (var subjectId in request.SubjectId)
                {
                    var subjectVotes = votes
                        .Where(v => v.SubjectId == subjectId)
                        .Select(vote => new VoteResponse
                        {
                            Count = vote.Count,
                            OptionName = vote.OptionName
                        });

                    var list = new LoadBatchResponse.Types.SubjectListResponse();
                    list.SubjectId = subjectId;
                    list.Votes.Add(subjectVotes);

                    batchResponse.Votes.Add(list);
                }

                return batchResponse;
            }
        }

        private VoteResponse ToResponse(Vote vote) => new VoteResponse
        {
            Count = vote.Count,
            OptionName = vote.OptionName,
        };
    }
}