using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class MedicineDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int QuantityAvailable { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int LaboratoryId { get; set; }
    public string Laboratory { get; set; }
}