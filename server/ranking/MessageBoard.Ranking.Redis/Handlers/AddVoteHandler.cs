using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MessageBoard.Ranking.Core.Commands;
using StackExchange.Redis;
using static MessageBoard.Ranking.Redis.Mappings;

namespace MessageBoard.Ranking.Redis.Handlers
{
    public class AddVoteHandler : IRequestHandler<AddVoteCommand>
    {
        private readonly IDatabase _db;

        public AddVoteHandler(IDatabase db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(AddVoteCommand request, CancellationToken cancellationToken)
        {
            await _db.SortedSetIncrementAsync(MapKey(request.OptionName), request.SubjectId, 1d);
            return Unit.Value;
        }
    }
}