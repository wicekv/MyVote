using Microsoft.AspNetCore.Mvc;
using MyVote.Application.DTO;
using MyVote.Application.Services;

namespace MyVote.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult> CreateCandidate([FromBody] CreateCandidateDto candidateDto, CancellationToken cancellationToken)
        {
            var result = await _candidateService.CreateCandidate(candidateDto, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<VoterDto>>> GetCandidates()
        {
            var result = await _candidateService.GetCandidates();

            return Ok(result);
        }
    }
}
