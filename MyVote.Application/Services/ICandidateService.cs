using MyVote.Application.DTO;

namespace MyVote.Application.Services
{
    public interface ICandidateService
    {
        Task<List<CandidateDto>> GetCandidates();
        Task<int> CreateCandidate(CreateCandidateDto createCandidate, CancellationToken cancellationToken);
    }
}
