using Caluspire.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caluspire.Application.Repositories
{
    public interface IJobRepository
    {
        Task<Job> GetJobByIdAsync(int jobId);
        Task SaveChangesAsync();
        Task<List<Job>> GetAllAsync();
        Task<bool> SubmitApplicationAsync(int candidateId, int jobId, string coverLetter, string resume);
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task AddAsync(Job job);
    }
}
