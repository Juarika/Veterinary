using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class DetailMovementRepository : GenericRepository<DetailMovement>, IDetailMovement
{
    private readonly SkelettonContext _context;

    public DetailMovementRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}