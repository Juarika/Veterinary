using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class MedicineMovementRepository : GenericRepository<MedicineMovement>, IMedicineMovement
{
    private readonly SkelettonContext _context;

    public MedicineMovementRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }

    public override async Task<IEnumerable<MedicineMovement>> GetWithPagination(int pageNumber, int pageSize)
    {
        int startIndex = (pageNumber - 1) * pageSize;

        var paginatedEntities = await _context.Set<MedicineMovement>()
            .Include(e => e.DetailMovements)
            .Include(e => e.MovementType)
            .Skip(startIndex)
            .Take(pageSize)
            .ToListAsync();

        return paginatedEntities;
    }
}