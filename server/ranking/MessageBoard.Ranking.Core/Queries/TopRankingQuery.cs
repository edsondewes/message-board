using System;
using System.Collections.Generic;
using MediatR;

namespace MessageBoard.Ranking.Core.Queries
{
    public class TopRankingQuery : IRequest<IEnumerable<VoteCount>>
    {
        public uint Length { get; }
        public string OptionName { get; }

        public TopRankingQuery(string optionName, uint length = 10)
        {
            if (string.IsNullOrWhiteSpace(optionName))
                throw new ArgumentNullException(nameof(optionName));

            if (length == 0)
                throw new ArgumentOutOfRangeException(nameof(length), length, "Length must be greater than zero");

            Length = length;
            OptionName = optionName;
        }
    }
}
