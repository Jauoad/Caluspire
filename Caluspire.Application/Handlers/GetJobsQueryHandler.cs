using AutoMapper;
using Caluspire.Application.Queries;
using Caluspire.Domain.Aggregate;
using Caluspire.Domain.Repositories;
using MediatR;

namespace Caluspire.Application.Handlers
{
    public class GetJobsQueryHandler : IRequestHandler<GetJobsQuery, List<Job>>
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public GetJobsQueryHandler(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task<List<Job>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _jobRepository.GetAllJobsAsync();

            if (!string.IsNullOrEmpty(request.Category))
            {
                jobs = jobs.Where(job => job.Category.Contains(request.Category, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(request.Location))
            {
                jobs = jobs.Where(job => job.Location.Contains(request.Location, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(request.Status))
            {
                jobs = jobs.Where(job => job.Status.Contains(request.Status, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            var jobAggregates = _mapper.Map<List<Job>>(jobs);

            return jobAggregates;
        }
    }
}