using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class PetDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [Required]
    public int OwnerId { get; set; }
    [Required]
    public int BreedId { get; set; }
    [Required]
    public int SpecieId { get; set; }
}
public class PetOwnerDto
{
    public string Name { get; set; }
}
public class PetWithOwnerDto
{
    public string Name { get; set; }
    public OwnerForDto Owner { get; set; }
}