using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MessageBoard.Voting.Core.Events;

namespace MessageBoard.Voting.Core.Commands
{
    public class AddVoteHandler : IRequestHandler<AddVoteCommand, Vote>
    {
        private readonly IMediator _mediator;
        private readonly IVoteRepository _repository;

        public AddVoteHandler(IMediator mediator, IVoteRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<Vote> Handle(AddVoteCommand request, CancellationToken cancellationToken)
        {
            var count = await _repository.Increment(request.SubjectId, request.OptionName);

            var obj = new Vote
            {
                Count = count,
                OptionName = request.OptionName,
                SubjectId = request.SubjectId
            };

            await _mediator.Publish(VoteCreated.From(obj));

            return obj;
        }
    }
}
