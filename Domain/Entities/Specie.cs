namespace Domain.Entities;

public class Specie : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Breed> Breeds { get; set; }
    public ICollection<Pet> Pets { get; set; }
}