using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class LaboratoryDto
{
    [Required]
    public string Name { get; set; } 
    [Required]
    public string Direction { get; set; }
    [Required]
    public string Phone { get; set; } 
}