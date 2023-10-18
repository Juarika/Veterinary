using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class MedicineSupplierRepository : GenericRepository<MedicineSupplier>, IMedicineSupplier
{
    private readonly SkelettonContext _context;

    public MedicineSupplierRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}