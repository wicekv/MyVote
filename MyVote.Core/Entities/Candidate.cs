using MyVote.Core.ValueObjects;

namespace MyVote.Core.Entities
{
    public class Candidate
    {
        public int Id { get; private set; }
        public CandidateName Name{ get; private set; }
        public int Votes { get; private set; }

        private Candidate(CandidateName name)
        {
            Name = name;
            Votes = 0;
        }

        public void IncreaseVotes()
        {
            Votes += 1;
        }

        public static Candidate Create(CandidateName name)
        {
            return new Candidate(name);
        }
    }
}
