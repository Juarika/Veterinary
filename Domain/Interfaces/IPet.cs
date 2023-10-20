using Domain.Entities;

namespace Domain.Interfaces;

public interface IPet : IGenericRepository<Pet>
{ 
    Task<IEnumerable<Pet>> GetForBreed(string _search);
}