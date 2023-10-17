namespace Domain.Entities;

public class Supplier : BaseEntity
{
    public string Name { get; set; }
    public string Direction { get; set; }
    public string Phone { get; set; }
    public ICollection<MedicineSupplier> MedicineSuppliers { get; set; }
    public ICollection<Medicine> Medicines { get; set; } = new HashSet<Medicine>();
}