using MyVote.Application.DTO;
using MyVote.Core.Entities;


namespace MyVote.Application.Mapping
{
    internal static class CandidateMapping
    {
        public static CandidateDto AsDto(this Candidate entity)
            => new CandidateDto(entity.Id, entity.Name, entity.Votes);
    }
}
