using AutoMapper;
using GazpromTest.DTO;
using GazpromTest.Models;

namespace GazpromTest.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WellDto, Well>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<Well, WellDto>();
        }
    }

}
