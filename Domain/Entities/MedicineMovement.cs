namespace Domain.Entities;

public class MedicineMovement : BaseEntity
{
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; }
    public ICollection<DetailMovement> DetailMovements { get; set; }
}