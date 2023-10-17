using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class MedicalTreatments : BaseEntity
{
    public int Dose { get; set; }
    public DateTime AdministrationDate { get; set; }
    public string Observation { get; set; }   
    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; }
    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; }
}