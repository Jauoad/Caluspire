using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caluspire.Domain.Repositories
{
    public interface IJobRepository
    {
        Task<Job> GetByIdAsync(int jobId);
        Task AddAsync(Job job);
        Task SaveChangesAsync();
    }

}
