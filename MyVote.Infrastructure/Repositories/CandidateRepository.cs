using Microsoft.EntityFrameworkCore;
using MyVote.Core.Entities;
using MyVote.Core.Repositories;
using MyVote.Infrastructure.Context;

namespace MyVote.Infrastructure.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly VotingDbContext _context;

        public CandidateRepository(VotingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Candidate candidate, CancellationToken cancellationToken)
        {
            await _context.Candidates.AddAsync(candidate, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Candidate candidate)
        {
            _context.Candidates.Update(candidate);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            return await _context.Candidates.ToListAsync();
        }

        public async Task<Candidate?> GetCandidate(int id)
        {
            return await _context.Candidates
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
