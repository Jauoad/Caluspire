using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Caluspire.Application.Handlers
{

    public class GetJobApplicationStatusQueryHandler : IRequestHandler<GetJobApplicationStatusQuery, string>
    {
        private readonly IJobRepository _jobRepository;

        public GetJobApplicationStatusQueryHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<string> Handle(GetJobApplicationStatusQuery request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetByIdAsync(request.CandidateId);
            var candidate = job.Candidates.FirstOrDefault(c => c.CandidateId == request.CandidateId);
            return candidate?.Status ?? "Not found";
        }
    }

}
