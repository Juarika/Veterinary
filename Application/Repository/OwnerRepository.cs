using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class OwnerRepository : GenericRepository<Owner>, IOwner
{
    private readonly SkelettonContext _context;

    public OwnerRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}