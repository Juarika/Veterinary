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

        CreateMap<Owner, OwnerForDto>()
        .ReverseMap();

        CreateMap<Owner, OwnerWithPetsDto>()
        .ForMember(e => e.Pets, opt => opt.MapFrom(e => e.Pets))
        .ReverseMap();

        CreateMap<Pet, PetWithOwnerDto>()
        .ForMember(e => e.Owner, opt => opt.MapFrom(e => e.Owner))
        .ReverseMap();

        CreateMap<Specie, SpecieWithPetsDto>()
        .ForMember(e => e.Pets, opt => opt.MapFrom(e => e.Pets))
        .ReverseMap();

        CreateMap<MedicineMovement, MovMedPriceDto>()
        .ForMember(e => e.MovementType, dest => dest.MapFrom(e => e.MovementType.Description))
        .ForMember(e => e.Total, dest => dest.MapFrom(e => e.DetailMovements.Select(e => e.Price).Sum()))
        .ReverseMap();

        CreateMap<Supplier, SupplierDto>().ReverseMap();

        CreateMap<Breed, BreedWithCountDto>()
        .ForMember(e => e.Quantity, opt => opt.MapFrom(e => e.Pets.Count))
        .ReverseMap();
    }
}