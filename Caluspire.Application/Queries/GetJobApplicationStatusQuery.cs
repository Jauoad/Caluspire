using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caluspire.Application.Queries
{
    public class GetJobApplicationStatusQuery : IRequest<string>
    {
        public int CandidateId { get; set; }
    }

}
