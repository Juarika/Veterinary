using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class MedicalTreatmentsDto
{
    [Required]
    public int Dose { get; set; }
    [Required]
    public DateTime AdministrationDate { get; set; }
    [Required]
    public string Observation { get; set; }   
    [Required]
    public int AppointmentId { get; set; }
    [Required]
    public int MedicineId { get; set; }
}