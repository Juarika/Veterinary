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

        CreateMap<Medicine, MedicineDto>()
        .ForMember(e => e.Laboratory, opt => opt.MapFrom(e => e.Laboratory.Name))
        .ReverseMap();

        CreateMap<Pet, PetDto>()
        // .ForMember(e => e.Laboratory, opt => opt.MapFrom(e => e.Laboratory.Name))
        .ReverseMap();

        CreateMap<Pet, PetOwnerDto>()
        .ReverseMap();

        CreateMap<Owner, OwnerDto>()
        .ReverseMap();

        CreateMap<Owner, OwnerWithPetsDto>()
        .ForMember(e => e.Pets, opt => opt.MapFrom(e => e.Pets))
        .ReverseMap();

        CreateMap<Specie, SpecieWithPetsDto>()
        .ForMember(e => e.Pets, opt => opt.MapFrom(e => e.Pets))
        .ReverseMap();
    }
}