namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRol Roles { get; }
    IUser Users { get; }
    IUserRol UserRoles { get; }
    IAppointment Appointments { get; }
    IBreed Breeds { get; }
    IDetailMovement DetailMovements { get; }
    ILaboratory Laboratories { get; }
    IMedicalTreatments MedicalTreatments { get; }
    IMedicine Medicines { get; }
    IMedicineMovement MedicineMovements { get; }
    IMedicineSupplier MedicineSuppliers { get; }
    IMovementType MovementTypes { get; }
    IOwner Owners { get; }
    IPet Pets { get; }
    ISpecie Species { get; }
    ISupplier Suppliers { get; }
    IVeterinarian Veterinarians { get; }
    Task<int> SaveAsync();
}