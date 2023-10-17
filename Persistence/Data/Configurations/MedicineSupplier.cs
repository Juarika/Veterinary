using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class MedicineSupplier
{
    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; }
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }
}