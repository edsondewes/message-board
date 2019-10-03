using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using MessageBoard.Ranking.Core;
using MessageBoard.Ranking.Core.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MessageBoard.Ranking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RankingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RankingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{optionName}")]
        public Task<IEnumerable<VoteCount>> Get(string optionName)
        {
            return _mediator.Send(new TopRankingQuery(optionName));
        }
    }
}
