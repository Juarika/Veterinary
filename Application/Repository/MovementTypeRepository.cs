using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class MovementTypeRepository : GenericRepository<MovementType>, IMovementType
{
    private readonly SkelettonContext _context;

    public MovementTypeRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}