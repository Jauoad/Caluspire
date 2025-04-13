using Caluspire.Domain.Entities;
using Caluspire.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Caluspire.Infrastructure.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _context;

        public JobRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Job job)
        {
            await _context.Jobs.AddAsync(job);
        }

        public async Task<Job> GetJobByIdAsync(int jobId)
        {
            return await _context.Jobs
                .Include(j => j.Candidates)
                .FirstOrDefaultAsync(j => j.Id == jobId);
        }

        public async Task<List<Job>> GetAllAsync()
        {
            return await _context.Jobs
                .Include(j => j.Candidates)
                .ToListAsync();
        }

        public async Task<bool> SubmitApplicationAsync(int candidateId, int jobId, string coverLetter, string resume)
        {
            var job = await GetJobByIdAsync(jobId);
            if (job == null) return false;

            var candidate = new Candidate(
                candidateId,
                "Candidate",
                new List<string> { "C#", "F#" },
                coverLetter,
                resume
            );

            job.AddCandidate(candidate);
            await SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}