using MyVote.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVote.Application.Exceptions
{
    public class CandidateNotFoundException : CustomException
    {
        public int CandidateId { get; private set; }
        public CandidateNotFoundException(int candidateId) : base($"Candidate with Id: '{candidateId}' was not found")
        {
            CandidateId = candidateId;
        }
    }
}
