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