using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class BreedRepository : GenericRepository<Breed>, IBreed
{
    private readonly SkelettonContext _context;

    public BreedRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}