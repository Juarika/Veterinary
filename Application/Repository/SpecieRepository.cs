using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class SpecieRepository : GenericRepository<Specie>, ISpecie
{
    private readonly SkelettonContext _context;

    public SpecieRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}