using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caluspire.Application.DTOs;
using MediatR;

namespace Caluspire.Application.Queries
{
    public class GetJobApplicationStatusQuery : IRequest<ApplicationStatusDto>
    {
        public int CandidateId { get; set; }

        public GetJobApplicationStatusQuery() { }
        public GetJobApplicationStatusQuery(int candidateId)
        {
            CandidateId = candidateId;
        }
    }
}

