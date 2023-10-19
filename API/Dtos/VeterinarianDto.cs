
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class VeterinarianDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Specialty { get; set; }
}