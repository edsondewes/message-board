using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MessageBoard.Voting.Core;
using MessageBoard.Voting.Core.Commands;
using StackExchange.Redis;
using static MessageBoard.Voting.Redis.Mappings;

namespace MessageBoard.Voting.Redis.Handlers
{
    public class AddVoteHandler : IRequestHandler<AddVoteCommand, Vote>
    {
        private readonly IDatabase _db;

        public AddVoteHandler(IDatabase db)
        {
            _db = db;
        }

        public async Task<Vote> Handle(AddVoteCommand request, CancellationToken cancellationToken)
        {
            var count = await _db.HashIncrementAsync(MapKey(request.SubjectId), request.OptionName);
            return new Vote
            {
                Count = (uint)count,
                OptionName = request.OptionName,
                SubjectId = request.SubjectId
            };
        }
    }
}
