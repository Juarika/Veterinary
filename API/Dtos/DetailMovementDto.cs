using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class DetailMovementDto
{
    [Required]
    public int Quantity { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int MedicineId { get; set; }
    [Required]
    public int MedicineMovementId { get; set; }
}