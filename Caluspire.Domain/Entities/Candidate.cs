using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caluspire.Domain.Entities
{
    public class Candidate
    {
        public int CandidateId { get; private set; }
        public string Name { get; private set; }
        public string Skills { get; private set; }
        public string Status { get; private set; }

        public Candidate(int candidateId, string name, string skills)
        {
            CandidateId = candidateId;
            Name = name;
            Skills = skills;
            Status = "Applied";
        }

        public void ChangeStatus(string newStatus)
        {
            Status = newStatus;
        }
    }

}
