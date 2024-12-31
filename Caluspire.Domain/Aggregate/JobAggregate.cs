using Caluspire.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caluspire.Domain.Aggregate
{
    public class Job
    {
        public int JobId { get; private set; }
        public string Title { get; private set; }
        private readonly List<Candidate> _candidates = new List<Candidate>();
        public IReadOnlyList<Candidate> Candidates => _candidates.AsReadOnly();

        public Job(int jobId, string title)
        {
            JobId = jobId;
            Title = title;
        }

        public void AddCandidate(Candidate candidate)
        {
            _candidates.Add(candidate);
        }
    }

}
