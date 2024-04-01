using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVote.Application.DTO
{
    public sealed record VoteDto(int CandidateId, int VoterId);
}
