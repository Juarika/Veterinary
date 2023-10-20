using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class MedicineMovementDto
{
    [Required]
    public int Quantity { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public int MedicineId { get; set; }
    [Required]
    public int MovementTypeId { get; set; }
}
public class MovMedPriceDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string MovementType { get; set; }
    public double Total {get; set;}
}