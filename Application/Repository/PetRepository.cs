using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class PetRepository : GenericRepository<Pet>, IPet
{
    private readonly SkelettonContext _context;

    public PetRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }

    public async Task<IEnumerable<Pet>> GetForBreed(string _search){
        return await _context.Set<Pet>()
        .Include(e => e.Breed)
        .Include(e => e.Owner)
        .Where(e => e.Breed.Name.ToLower() == _search)
        .ToListAsync();
    }
}