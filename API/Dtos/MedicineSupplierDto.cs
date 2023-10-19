using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class MedicineSupplierDto
{
    [Required]
    public int MedicineId { get; set; }
    [Required]
    public int SupplierId { get; set; }
}