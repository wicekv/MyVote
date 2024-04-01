using Microsoft.EntityFrameworkCore;
using MyVote.Core.Entities;
using MyVote.Core.Repositories;
using MyVote.Infrastructure.Context;


namespace MyVote.Infrastructure.Repositories
{
    internal sealed class VoterRepository : IVoterRepository
    {
        private readonly VotingDbContext _context;

        public VoterRepository(VotingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Voter voter)
        {
            await _context.Voters.AddAsync(voter);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Voter>> GetVoters()
        {
            return await _context.Voters
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Voter?> GetVoter(int id)
        {
            return await _context.Voters
                .Where(v => v.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Voter voter)
        {
            _context.Voters.Update(voter);

            await _context.SaveChangesAsync();
        }
    }
}
