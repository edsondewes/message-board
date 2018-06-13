using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageBoard.GraphQL.Model;
using MessageBoard.Messaging.GRPC;
using MessageBoard.Ranking.GRPC;
using MessageBoard.Voting.GRPC;

namespace MessageBoard.GraphQL.GRPC
{
    public class RepositoryGrpc : IRepository
    {
        private readonly MessageService.MessageServiceClient _messageClient;
        private readonly RankingService.RankingServiceClient _rankingClient;
        private readonly VoteService.VoteServiceClient _voteClient;

        public RepositoryGrpc(
            MessageService.MessageServiceClient messageClient,
            RankingService.RankingServiceClient rankingClient,
            VoteService.VoteServiceClient voteClient)
        {
            _messageClient = messageClient;
            _rankingClient = rankingClient;
            _voteClient = voteClient;
        }

        public async Task<Vote> AddVote(AddVoteModel model)
        {
            var request = new AddRequest
            {
                OptionName = model.OptionName,
                SubjectId = model.SubjectId
            };

            var vote = await _voteClient.AddAsync(request);
            return ToModel(vote);
        }

        public async Task<Message> CreateMessage(CreateMessageModel model)
        {
            var request = new CreateRequest
            {
                Text = model.Text
            };

            var message = await _messageClient.CreateAsync(request);
            return ToModel(message);
        }

        public async Task<Message> GetMessage(long id)
        {
            var request = new Messaging.GRPC.SingleRequest
            {
                Id = id
            };

            var message = await _messageClient.SingleAsync(request);
            return ToModel(message);
        }

        public async Task<IEnumerable<Message>> ListMessages(long? from)
        {
            var request = new Messaging.GRPC.ListRequest
            {
                From = from ?? 0
            };

            var list = await _messageClient.ListAsync(request);
            return list.Messages.Select(ToModel);
        }

        public async Task<IEnumerable<MessageRanking>> ListMessagesByRanking(string optionName)
        {
            var request = new Ranking.GRPC.ListRequest
            {
                OptionName = optionName
            };

            var ranking = await _rankingClient.ListAsync(request);
            return ranking.Votes.Select(ToModel);
        }

        public async Task<IEnumerable<Vote>> ListVotes(string subjectId, string optionName = null)
        {
            var request = new Voting.GRPC.SingleRequest
            {
                SubjectId = subjectId
            };

            var list = await _voteClient.SingleAsync(request);

            //TODO: filter in the GPRC side
            var filtered = optionName != null
                ? list.Votes.Where(v => v.OptionName == optionName)
                : list.Votes;

            return filtered.Select(ToModel);
        }

        private Message ToModel(MessageResponse obj) => new Message
        {
            Created = obj.Created.ToDateTime().ToLocalTime(),
            Id = obj.Id,
            Text = obj.Text
        };

        private MessageRanking ToModel(RankingResponse.Types.VoteCountResponse obj) => new MessageRanking
        {
            SubjectId = obj.SubjectId,
            VoteCount = obj.Count
        };

        private Vote ToModel(VoteResponse obj) => new Vote
        {
            Count = obj.Count,
            OptionName = obj.OptionName
        };
    }
}