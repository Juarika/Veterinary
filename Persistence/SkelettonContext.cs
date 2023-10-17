using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class SkelettonContext : DbContext
{
    public SkelettonContext(DbContextOptions options) : base(options)
    { }
    public DbSet<User> Users { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<UserRol> UserRoles { get; set; }
    public DbSet<Veterinarian> Veterinarians { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Specie> Species { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<MovementType> MovementTypes { get; set; }
    public DbSet<MedicineSupplier> MedicineSuppliers { get; set; }
    public DbSet<MedicineMovement> MedicineMovements { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<MedicalTreatments> MedicalTreatments { get; set; }
    public DbSet<Laboratory> Laboratories { get; set; }
    public DbSet<DetailMovement> DetailMovements { get; set; }
    public DbSet<Breed> Breeds { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}