using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SkelettonContext _context;
    private IRol _roles;
    private IUser _users;
    private IUserRol _userole;
    private IAppointment _appointments;
    private IBreed _breeds;
    private IDetailMovement _detailmovements;
    private ILaboratory _laboraties;
    private IMedicalTreatments _medicalTreatments;
    private IMedicine _medicines;
    private IMedicineMovement _medicineMovements;
    private IMedicineSupplier _medicineSuppliers;
    private IMovementType _movementTypes;
    private IOwner _owners;
    private IPet _pets;
    private ISpecie _species;
    private ISupplier _suppliers;
    private IVeterinarian _veterinarians;
    public UnitOfWork(SkelettonContext context)
    {
        _context = context;
    }
    public IRol Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }
    public IUserRol UserRoles
    {
        get
        {
            if (_userole == null)
            {
                _userole = new UseRolRepository(_context);
            }
            return _userole;
        }
    }
    public IUser Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context);
            }
            return _users;
        }
    }
    public IAppointment Appointments
    {
        get
        {
            if (_appointments == null)
            {
                _appointments = new AppointmentRepository(_context);
            }
            return _appointments;
        }
    }
    public IBreed Breeds
    {
        get
        {
            if (_breeds == null)
            {
                _breeds = new BreedRepository(_context);
            }
            return _breeds;
        }
    }
    public IDetailMovement DetailMovements
    {
        get
        {
            if (_detailmovements == null)
            {
                _detailmovements = new DetailMovementRepository(_context);
            }
            return _detailmovements;
        }
    }
    public ILaboratory Laboratories
    {
        get
        {
            if (_laboraties == null)
            {
                _laboraties = new LaboratoryRepository(_context);
            }
            return _laboraties;
        }
    }
    public IMedicalTreatments MedicalTreatments
    {
        get
        {
            if (_medicalTreatments == null)
            {
                _medicalTreatments = new MedicalTreatmentsRepository(_context);
            }
            return _medicalTreatments;
        }
    }
    public IMedicine Medicines
    {
        get
        {
            if (_medicines == null)
            {
                _medicines = new MedicineRepository(_context);
            }
            return _medicines;
        }
    }
    public IMedicineMovement MedicineMovements
    {
        get
        {
            if (_medicineMovements == null)
            {
                _medicineMovements = new MedicineMovementRepository(_context);
            }
            return _medicineMovements;
        }
    }
    public IMedicineSupplier MedicineSuppliers
    {
        get
        {
            if (_medicineSuppliers == null)
            {
                _medicineSuppliers = new MedicineSupplierRepository(_context);
            }
            return _medicineSuppliers;
        }
    }
    public IMovementType MovementTypes
    {
        get
        {
            if (_movementTypes == null)
            {
                _movementTypes = new MovementTypeRepository(_context);
            }
            return _movementTypes;
        }
    }
    public IOwner Owners
    {
        get
        {
            if (_owners == null)
            {
                _owners = new OwnerRepository(_context);
            }
            return _owners;
        }
    }
    public IPet Pets
    {
        get
        {
            if (_pets == null)
            {
                _pets = new PetRepository(_context);
            }
            return _pets;
        }
    }
    public ISpecie Species
    {
        get
        {
            if (_species == null)
            {
                _species = new SpecieRepository(_context);
            }
            return _species;
        }
    }
    public ISupplier Suppliers
    {
        get
        {
            if (_suppliers == null)
            {
                _suppliers = new SupplierRepository(_context);
            }
            return _suppliers;
        }
    }
    public IVeterinarian Veterinarians
    {
        get
        {
            if (_veterinarians == null)
            {
                _veterinarians = new VeterinarianRepository(_context);
            }
            return _veterinarians;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}