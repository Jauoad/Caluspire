using MediatR;

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
