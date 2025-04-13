using Caluspire.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caluspire.Application.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetJobByIdAsync(int candidateId);
        Task<IEnumerable<Candidate>> GetAllAsync();
        Task AddAsync(Candidate candidate);
        Task SaveChangesAsync();
    }
}
