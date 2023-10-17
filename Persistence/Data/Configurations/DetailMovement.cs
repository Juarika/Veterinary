using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class DetailMovement : BaseEntity
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; }
    public int MedicineMovementId { get; set; }
    public MedicineMovement MedicineMovement { get; set; }
}