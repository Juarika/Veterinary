using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserWithRolDto>()
        .ForMember(dest => dest.RolName, opt => opt.MapFrom(src => src.Roles.FirstOrDefault().Name))
        .ReverseMap();

        CreateMap<Veterinarian, VeterinarianDto>()
        .ReverseMap()
        .ForMember(m => m.Appointments, d => d.Ignore());
    }
}