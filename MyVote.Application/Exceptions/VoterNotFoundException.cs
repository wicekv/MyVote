using MyVote.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVote.Application.Exceptions
{
    internal class VoterNotFoundException : CustomException
    {
        public int VoterId { get; private set; }
        public VoterNotFoundException(int voterId) : base($"Candidate with Id: '{voterId}' was not found")
        {
            VoterId = voterId;
        }
    }
}
