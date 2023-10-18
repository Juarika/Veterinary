using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class LaboratoryRepository : GenericRepository<Laboratory>, ILaboratory
{
    private readonly SkelettonContext _context;

    public LaboratoryRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}