using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class BreedDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int SpecieId { get; set; }
}