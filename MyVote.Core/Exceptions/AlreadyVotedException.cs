using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVote.Core.Exceptions
{
    public sealed class AlreadyVotedException : CustomException
    {
        public AlreadyVotedException() : base($"You have already voted")
        {
        }
    }
}
