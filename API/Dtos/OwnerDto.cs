using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class OwnerDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
}
public class OwnerWithPetsDto
{
    public string Name { get; set; }
    public ICollection<PetOwnerDto> Pets { get; set; }
}