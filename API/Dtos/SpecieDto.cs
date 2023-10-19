using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class SpecieDto
{
    [Required]
    public string Name { get; set; }
}