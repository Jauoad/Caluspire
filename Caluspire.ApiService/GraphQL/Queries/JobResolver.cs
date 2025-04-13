using Caluspire.Domain.Entities;
using Caluspire.Domain.Repositories;
using HotChocolate;

namespace Caluspire.ApiService.GraphQL.Queries
{
    public class JobResolver
    {
        private readonly IJobRepository _jobRepository;

        public JobResolver(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<Job> GetJob(int id)
        {
            return await _jobRepository.GetJobByIdAsync(id);
        }
    }
}
