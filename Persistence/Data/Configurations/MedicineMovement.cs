using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class MedicineMovement : BaseEntity
{
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; }
    public ICollection<DetailMovement> DetailMovements { get; set; }
}