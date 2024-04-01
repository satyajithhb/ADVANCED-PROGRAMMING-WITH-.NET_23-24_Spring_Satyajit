using AutoMapper;
using MidAssignment_ZeroHunger.DTOs;
using MidAssignment_ZeroHunger.EF;

namespace MidAssignment_ZeroHunger
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }

        public static void Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeesDTO, Employee>()
                   .ForMember(dest => dest.NgoId, opt => opt.MapFrom(src => 1)); 
                cfg.CreateMap<Employee, EmployeesDTO>()
                   .ForMember(dest => dest.NgoId, opt => opt.MapFrom(src => src.NgoId));
                cfg.CreateMap<Collect_Request, CollectRequestDTO>().ReverseMap();
            });

            Mapper = config.CreateMapper();
        }
    }

}