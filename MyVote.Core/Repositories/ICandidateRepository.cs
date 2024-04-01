using MyVote.Core.Entities;

namespace MyVote.Core.Repositories
{
    public interface ICandidateRepository
    {
        Task AddAsync(Candidate candidate, CancellationToken cancellationToken);
        Task<IEnumerable<Candidate>> GetCandidates();
        Task<Candidate?> GetCandidate(int id);
        Task UpdateAsync(Candidate candidate);
    }
}
