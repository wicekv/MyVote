using MyVote.Core.Entities;

namespace MyVote.Core.Repositories
{
    public interface IVoterRepository
    {
        Task AddAsync(Voter voter);
        Task<IEnumerable<Voter>> GetVoters();
        Task<Voter?> GetVoter(int id);
        Task UpdateAsync(Voter voter);
    }
}
