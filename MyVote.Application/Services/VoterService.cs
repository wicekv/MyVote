using MyVote.Application.DTO;
using MyVote.Application.Exceptions;
using MyVote.Application.Mapping;
using MyVote.Core.Entities;
using MyVote.Core.Repositories;
using MyVote.Core.ValueObjects;

namespace MyVote.Application.Services
{
    internal sealed class VoterService : IVoterService
    {
        private readonly IVoterRepository _voterRepository;
        private readonly ICandidateRepository _candidateRepository;
        
        public VoterService(IVoterRepository voterRepository, ICandidateRepository candidateRepository)
        {
            _voterRepository = voterRepository;
            _candidateRepository = candidateRepository;
        }

        public async Task<int> CreateVoter(CreateVoterDto voterDto)
        {
            var voter = Voter.Create(new VoterName(voterDto.Name));

            await _voterRepository.AddAsync(voter);

            return voter.Id;
        }

        public async Task VoteForTheCandidate(VoteDto voteDto)
        {
            var voter = await _voterRepository.GetVoter(voteDto.VoterId);

            if (voter is null)
            {
                throw new VoterNotFoundException(voteDto.VoterId);
            }

            var candidate = await _candidateRepository.GetCandidate(voteDto.CandidateId);

            if (candidate is null)
            {
                throw new CandidateNotFoundException(voteDto.CandidateId);
            }

            voter.ChangeHasVoted();

            candidate.IncreaseVotes();

            await _voterRepository.UpdateAsync(voter);
            await _candidateRepository.UpdateAsync(candidate);
        }

        public async Task<List<VoterDto>> GetVoters()
        {
            var voters = await _voterRepository.GetVoters();

            return voters
                .Select(voter => voter.AsDto())
                .ToList();
        }
    }
}
