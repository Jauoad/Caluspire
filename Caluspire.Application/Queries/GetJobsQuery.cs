using Caluspire.Domain.Aggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caluspire.Application.Queries
{
    public class GetJobsQuery : IRequest<List<Job>>
    {
        public string Category { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
    }
}
