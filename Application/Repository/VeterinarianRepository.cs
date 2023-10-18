using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class VeterinarianRepository : GenericRepository<Veterinarian>, IVeterinarian
{
    private readonly SkelettonContext _context;

    public VeterinarianRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}