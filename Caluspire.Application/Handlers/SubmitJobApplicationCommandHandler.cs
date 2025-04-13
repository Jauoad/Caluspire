using Caluspire.Application.Commands;
using Caluspire.Application.Repositories;
using Caluspire.Domain.Entities;
using MediatR;

namespace Caluspire.Application.Handlers
{
    public class SubmitJobApplicationCommandHandler : IRequestHandler<SubmitJobApplicationCommand, bool>
    {
        private readonly IJobRepository _jobRepository;

        public SubmitJobApplicationCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<bool> Handle(SubmitJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetJobByIdAsync(request.JobId);
            if (job == null)
            {
                return false;
            }

            var existingCandidate = job.Candidates.FirstOrDefault(c => c.CandidateId == request.CandidateId);
            if (existingCandidate != null)
            {
                return false;
            }

            var candidate = new Candidate(
                request.CandidateId,
                request.CandidateName,
                request.CandidateSkills,
                request.CoverLetter,
                request.Resume
            );

            job.AddCandidate(candidate);
            await _jobRepository.SaveChangesAsync();

            return true;
        }

    }
}