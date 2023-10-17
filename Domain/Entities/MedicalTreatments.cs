namespace Domain.Entities;

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