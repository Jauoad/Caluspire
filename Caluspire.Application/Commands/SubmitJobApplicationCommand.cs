using MediatR;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caluspire.Application.Commands
{
    public class SubmitJobApplicationCommand : IRequest<bool>
    {
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public List<string> CandidateSkills { get; set; }
        public int JobId { get; set; }
        public string CoverLetter { get; set; }
        public string Resume { get; set; }
    }

}
