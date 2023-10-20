using Domain.Entities;

namespace Domain.Interfaces;

public interface ISupplier : IGenericRepository<Supplier>
{ 
    Task<IEnumerable<Supplier>> GetForMedicine(string name);
}