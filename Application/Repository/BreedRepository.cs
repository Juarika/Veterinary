using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class BreedRepository : GenericRepository<Breed>, IBreed
{
    private readonly SkelettonContext _context;

    public BreedRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }

    public override async Task<IEnumerable<Breed>> GetWithPagination(int pageNumber, int pageSize)
    {
        int startIndex = (pageNumber - 1) * pageSize;
        
        var registros = await _context.Set<Breed>()
            .Include(e => e.Pets )
            .Skip(startIndex)
            .Take(pageSize)
            .ToListAsync();
        return registros;
    }
}