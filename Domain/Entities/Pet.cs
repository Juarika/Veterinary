namespace Domain.Entities;

public class Pet : BaseEntity
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public int OwnerId { get; set; }
    public Owner Owner { get; set; }
    public int BreedId { get; set; }
    public Breed Breed { get; set; }
    public int SpecieId { get; set; }
    public Specie Specie { get; set; }
    public ICollection<Appointment> Appointments { get; set; }   
}