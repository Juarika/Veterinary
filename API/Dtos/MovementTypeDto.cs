using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class MovementTypeDto
{
    [Required]
    public string Description { get; set; }
}