using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace Caluspire.Domain.Entities
{
    public class Candidate
    {
        public int CandidateId { get; private set; }
        public string Name { get; private set; }
        public List<string> Skills { get; private set; } = new();
        public string Status { get; private set; }

        public string CoverLetter { get; private set; }
        public string Resume { get; private set; }      

        public int JobId { get; set; }

        public Candidate(int candidateId, string name, List<string> skills, string coverLetter, string resume)
        {
            CandidateId = candidateId;
            Name = name;
            Skills = skills ?? new List<string>();
            CoverLetter = coverLetter;
            Resume = resume;
            Status = "Applied";
        }

        public Candidate() { }

        public void ChangeStatus(string newStatus)
        {
            Status = newStatus;
        }
    }

}
