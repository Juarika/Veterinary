namespace Domain.Entities;

public class Medicine : BaseEntity
{
    public string Name { get; set; }
    public int QuantityAvailable { get; set; }
    public decimal Price { get; set; }
    public int LaboratoryId { get; set; }
    public Laboratory Laboratory { get; set; }
    public ICollection<DetailMovement> DetailMovements { get; set; }
    public ICollection<MedicalTreatments> MedicalTreatments { get; set; }
    public ICollection<MedicineMovement> MedicineMovements { get; set; }
    public ICollection<Supplier> Suppliers { get; set; } = new HashSet<Supplier>();
    public ICollection<MedicineSupplier> MedicineSuppliers { get; set; }
}