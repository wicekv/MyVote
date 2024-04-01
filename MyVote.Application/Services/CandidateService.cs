using MyVote.Application.DTO;
using MyVote.Application.Mapping;
using MyVote.Core.Entities;
using MyVote.Core.Repositories;
using MyVote.Core.ValueObjects;

namespace MyVote.Application.Services
{
    internal sealed class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<int> CreateCandidate(CreateCandidateDto createCandidate, CancellationToken cancellationToken)
        {
            var candidate = Candidate.Create(new CandidateName(createCandidate.Name));

            await _candidateRepository.AddAsync(candidate, cancellationToken);

            return candidate.Id;
        }
        public async Task<List<CandidateDto>> GetCandidates()
        {
            var candidates = await _candidateRepository.GetCandidates();

            return candidates
                .Select(c => c.AsDto())
                .ToList();
        }
    }
}
