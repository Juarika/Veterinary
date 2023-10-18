using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class MedicineRepository : GenericRepository<Medicine>, IMedicine
{
    private readonly SkelettonContext _context;

    public MedicineRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}