using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MessageBoard.Ranking.Core.Commands
{
    public class AddVoteHandler : IRequestHandler<AddVoteCommand>
    {
        private readonly IMediator _mediator;
        private readonly IRankingRepository _repository;

        public AddVoteHandler(IMediator mediator, IRankingRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public Task Handle(AddVoteCommand request, CancellationToken cancellationToken)
        {
            return _repository.Increment(request.OptionName, request.SubjectId);
        }
    }
}