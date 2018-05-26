using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MessageBoard.Voting.Core;
using MessageBoard.Voting.Core.Queries;
using StackExchange.Redis;
using static MessageBoard.Voting.Redis.Mappings;

namespace MessageBoard.Voting.Redis.Handlers
{
    public class VoteCountHandler : IRequestHandler<VoteCountQuery, IEnumerable<Vote>>
    {
        private readonly IDatabase _db;

        public VoteCountHandler(IDatabase db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Vote>> Handle(VoteCountQuery request, CancellationToken cancellationToken)
        {
            var entries = await _db.HashGetAllAsync(MapKey(request.SubjectId));
            return entries.Select(e => new Vote
            {
                Count = (uint)e.Value,
                OptionName = e.Name,
                SubjectId = request.SubjectId
            });
        }
    }
}
