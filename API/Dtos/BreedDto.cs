using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class BreedDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int SpecieId { get; set; }
}
public class BreedWithCountDto
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}