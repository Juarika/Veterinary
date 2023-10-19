using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class SpecieDto
{
    [Required]
    public string Name { get; set; }
}
public class SpecieWithPetsDto
{
    public string Name { get; set; }
    public IEnumerable<PetOwnerDto> Pets { get; set; }
}