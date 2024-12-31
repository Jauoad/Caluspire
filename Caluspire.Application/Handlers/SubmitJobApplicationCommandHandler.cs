using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caluspire.Application.Handlers
{
    using Caluspire.Application.Commands;
    using MediatR;

    public class SubmitJobApplicationCommandHandler : IRequestHandler<SubmitJobApplicationCommand>
    {
        private readonly IJobRepository _jobRepository;

        public SubmitJobApplicationCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<Unit> Handle(SubmitJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetByIdAsync(request.JobId);
            var candidate = new Candidate(request.CandidateId, request.CandidateName, request.CandidateSkills);
            job.AddCandidate(candidate);
            await _jobRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }

}
