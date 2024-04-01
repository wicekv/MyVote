using Microsoft.EntityFrameworkCore;
using MyVote.Core.Entities;
using MyVote.Core.ValueObjects;


namespace MyVote.Infrastructure.Context
{
    public class VotingDbContext : DbContext
    {
        public VotingDbContext(DbContextOptions<VotingDbContext> options) : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Voter> Voters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Candidate>()
                .Property(c => c.Name)
                .HasConversion(c => c.Value, c => new CandidateName(c))
                .IsRequired()
                .HasMaxLength(50);

            builder.Entity<Voter>()
                .Property(v => v.Name)
                 .HasConversion(c => c.Value, c => new VoterName(c))
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
