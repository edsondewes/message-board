using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MessageBoard.Voting.Core.Commands
{
    public class AddVoteHandler : IRequestHandler<AddVoteCommand, Vote>
    {
        private IVoteRepository _repository;

        public AddVoteHandler(IVoteRepository repository)
        {
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

            return obj;
        }
    }
}
