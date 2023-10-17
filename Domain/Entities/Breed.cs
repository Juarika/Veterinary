namespace Domain.Entities;

public class Breed : BaseEntity
{
    public string Name { get; set; }
    public int SpecieId { get; set; }
    public Specie Specie { get; set; }
    public ICollection<Pet> Pets { get; set; }
}