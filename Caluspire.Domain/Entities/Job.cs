using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caluspire.Domain.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public List<Candidate> Candidates { get; set; } = new();
        public Job(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
            Candidates = new List<Candidate>();
        }
        public void AddCandidate(Candidate candidate)
        {
            Candidates.Add(candidate);
        }
    }
}
