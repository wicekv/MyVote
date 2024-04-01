using MyVote.Application.DTO;
using MyVote.Core.Entities;

namespace MyVote.Application.Mapping
{
    internal static class VoterMapping
    {
        public static VoterDto AsDto(this Voter entity)
            => new VoterDto(entity.Id, entity.Name, entity.HasVoted);
    }
}
