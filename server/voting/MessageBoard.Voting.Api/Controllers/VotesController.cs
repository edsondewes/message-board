using System.Threading.Tasks;
using MediatR;
using MessageBoard.Voting.Api.Models;
using MessageBoard.Voting.Core.Commands;
using MessageBoard.Voting.Core.Events;
using MessageBoard.Voting.Core.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MessageBoard.Voting.Api.Controllers
{
    [Route("api/[controller]")]
    public class VotesController : Controller
    {
        private readonly IMediator _mediator;

        public VotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{subjectId}")]
        public async Task<ActionResult> Get(string subjectId)
        {
            if (string.IsNullOrEmpty(subjectId))
                return BadRequest("Invalid subjectId");

            var result = await _mediator.Send(new VoteCountQuery(subjectId));
            var view = ViewVote.From(result);

            return Ok(view);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddVoteModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new AddVoteCommand(model.SubjectId, model.OptionName));
            await _mediator.Publish(VoteCreated.From(result));

            var view = ViewVote.From(result);
            return Ok(view);
        }
    }
}
