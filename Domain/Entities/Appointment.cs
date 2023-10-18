namespace Domain.Entities;

public class Appointment : BaseEntity
{
    public DateTime Date { get; set; }
    public DateTime Hour { get; set; }
    public string Reason { get; set; }
    public int VeterinarianId { get; set; }
    public Veterinarian Veterinarian { get; set; }
    public int PetId { get; set; }
    public Pet Pet { get; set; }
    public ICollection<MedicalTreatments> MedicalTreatments { get; set; }
}