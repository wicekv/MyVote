using Microsoft.AspNetCore.Mvc;
using MyVote.Application.DTO;
using MyVote.Application.Services;

namespace MyVote.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class VotersController : ControllerBase
    {
        private readonly IVoterService _voterService;

        public VotersController(IVoterService voterService)
        {
            _voterService = voterService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult> CreateVoter([FromBody] CreateVoterDto voterDto)
        {
            var result = await _voterService.CreateVoter(voterDto);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<VoterDto>>> GetVoters()
        {
            var result = await _voterService.GetVoters();

            return Ok(result);
        }

        [Route("vote")]
        [HttpPatch]
        public async Task<ActionResult> Vote([FromBody] VoteDto voteDto)
        {
            await _voterService.VoteForTheCandidate(voteDto);

            return Ok();
        }
    }
}
