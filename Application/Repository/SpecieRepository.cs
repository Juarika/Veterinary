using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class SpecieRepository : GenericRepository<Specie>, ISpecie
{
    private readonly SkelettonContext _context;

    public SpecieRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }

    public override async Task<IEnumerable<Specie>> GetWithPagination(int pageNumber, int pageSize)
    {
        int startIndex = (pageNumber - 1) * pageSize;

        var paginatedEntities = await _context.Set<Specie>()
            .Include(e => e.Pets)
            .Skip(startIndex)
            .Take(pageSize)
            .ToListAsync();

        return paginatedEntities;
    }
}