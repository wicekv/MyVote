using MyVote.Core.Exceptions;
using MyVote.Core.ValueObjects;

namespace MyVote.Core.Entities
{
    public class Voter
    {
        public int Id { get; private set; }
        public VoterName Name { get; private set; }
        public bool HasVoted { get; private set; }

        private Voter(VoterName name)
        {
            Name = name;
            HasVoted = false;
        }

        public void ChangeHasVoted()
        {
            if (HasVoted)
            {
                throw new AlreadyVotedException();
            }

            HasVoted = true;
        }

        public static Voter Create(VoterName name)
        {
            return new Voter(name);
        }
    }
}
