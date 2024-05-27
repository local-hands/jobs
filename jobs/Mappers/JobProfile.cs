using AutoMapper;
using localhands.Jobs.Models;
using localhands.Jobs.DTOs;

namespace localhands.Jobs.Mappers
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<JobCategoryDto, JobCategory>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<JobCategory, JobCategoryDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
