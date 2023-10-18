using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class PetRepository : GenericRepository<Pet>, IPet
{
    private readonly SkelettonContext _context;

    public PetRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}