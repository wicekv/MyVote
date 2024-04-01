using MyVote.Application.DTO;

namespace MyVote.Application.Services
{
    public interface IVoterService
    {
        Task<int> CreateVoter(CreateVoterDto createVoter);
        Task<List<VoterDto>> GetVoters();
        Task VoteForTheCandidate(VoteDto voteDto);
    }
}
