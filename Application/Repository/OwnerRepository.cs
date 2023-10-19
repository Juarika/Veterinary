using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class OwnerRepository : GenericRepository<Owner>, IOwner
{
    private readonly SkelettonContext _context;

    public OwnerRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }

    public override async Task<IEnumerable<Owner>> GetWithPagination(int pageNumber, int pageSize)
    {
        int startIndex = (pageNumber - 1) * pageSize;

        var paginatedEntities = await _context.Set<Owner>()
            .Include(e => e.Pets)
            .Skip(startIndex)
            .Take(pageSize)
            .ToListAsync();

        return paginatedEntities;
    }
}