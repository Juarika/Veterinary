namespace Domain.Entities;

public class DetailMovement : BaseEntity
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; }
    public int MedicineMovementId { get; set; }
    public MedicineMovement MedicineMovement { get; set; }
}