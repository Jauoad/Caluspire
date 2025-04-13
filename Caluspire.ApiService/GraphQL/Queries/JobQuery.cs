using Caluspire.Domain.Repositories;
using Caluspire.Domain.Entities;
using HotChocolate;

namespace Caluspire.ApiService.GraphQL.Queries
{
    public class JobQuery
    {
        private readonly IJobRepository _jobRepository;

        public JobQuery(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<IEnumerable<Job>> GetJobs()
        {
            return await _jobRepository.GetAllJobsAsync();
        }
    }
}
