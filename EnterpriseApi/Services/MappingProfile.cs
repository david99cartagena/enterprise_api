using AutoMapper;
using EnterpriseApi.DTOs.code;
using EnterpriseApi.DTOs.enterprise;

namespace EnterpriseApi.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Enterprise
            CreateMap<Enterprise, EnterpriseReadDto>()
                .ForMember(dest => dest.Codes,opt => opt.MapFrom(src => src.Codes));
            CreateMap<CreateEnterpriseDto, Enterprise>();
            CreateMap<UpdateEnterpriseDto, Enterprise>();

            // Code
            CreateMap<Code, CodeReadDto>();
            CreateMap<CreateCodeDto, Code>();
            CreateMap<UpdateCodeDto, Code>();
        }
    }
}
