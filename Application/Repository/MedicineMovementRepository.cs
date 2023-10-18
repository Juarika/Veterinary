using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class MedicineMovementRepository : GenericRepository<MedicineMovement>, IMedicineMovement
{
    private readonly SkelettonContext _context;

    public MedicineMovementRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}