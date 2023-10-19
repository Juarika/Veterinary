using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class MedicineRepository : GenericRepository<Medicine>, IMedicine
{
    private readonly SkelettonContext _context;

    public MedicineRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }

    public override IEnumerable<Medicine> Find(Expression<Func<Medicine, bool>> expression)
    {
        return _context.Set<Medicine>().Include(e => e.Laboratory).Where(expression);
    }
}