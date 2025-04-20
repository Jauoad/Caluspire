using AutoMapper;
using JobEntities = Caluspire.Domain.Entities.Job;
using JobAggregate = Caluspire.Domain.Aggregate.Job;

namespace Caluspire.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JobEntities, JobAggregate>();
        }
    }
}
