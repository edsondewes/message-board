using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MessageBoard.Voting.Core;
using MessageBoard.Voting.Core.Commands;
using MessageBoard.Voting.Core.Events;
using StackExchange.Redis;
using static MessageBoard.Voting.Redis.Mappings;

namespace MessageBoard.Voting.Redis.Handlers
{
    public class AddVoteHandler : IRequestHandler<AddVoteCommand, Vote>
    {
        private readonly IDatabase _db;
        private readonly IMediator _mediator;

        public AddVoteHandler(IDatabase db, IMediator mediator)
        {
            _db = db;
            _mediator = mediator;
        }

        public async Task<Vote> Handle(AddVoteCommand request, CancellationToken cancellationToken)
        {
            var count = await _db.HashIncrementAsync(MapKey(request.SubjectId), request.OptionName);
            var vote = new Vote
            {
                Count = (uint)count,
                OptionName = request.OptionName,
                SubjectId = request.SubjectId
            };

            await _mediator.Publish(VoteCreated.From(vote));

            return vote;
        }
    }
}
