namespace Domain.Entities;

public class MovementType : BaseEntity
{
    public string Description { get; set; }
    public ICollection<MedicineMovement> MedicineMovements { get; set; }
}