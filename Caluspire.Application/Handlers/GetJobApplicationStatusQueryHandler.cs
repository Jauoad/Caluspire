using System;
using System.Collections.Generic;
using Caluspire.Application.Queries;
using Caluspire.Application.DTOs;
using MediatR;
using Caluspire.Domain.Repositories;

namespace Caluspire.Application.Handlers
{
    public class GetJobApplicationStatusQueryHandler : IRequestHandler<GetJobApplicationStatusQuery, ApplicationStatusDto>
    {
        private readonly IJobRepository _jobRepository;

        public GetJobApplicationStatusQueryHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<ApplicationStatusDto> Handle(GetJobApplicationStatusQuery request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetJobByIdAsync(request.CandidateId);
            var candidate = job.Candidates.FirstOrDefault(c => c.CandidateId == request.CandidateId);

            return new ApplicationStatusDto
            {
                CandidateId = request.CandidateId,
                Status = candidate?.Status ?? "Not found"
            };
        }
    }


}
