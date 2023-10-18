using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class MedicineMovementConfiguration : IEntityTypeConfiguration<MedicineMovement>
{
    public void Configure(EntityTypeBuilder<MedicineMovement> builder)
    {
        builder.ToTable("medicineMovement");

        builder.Property(p => p.Quantity)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.Date)
        .HasColumnType("DateTime")
        .IsRequired();

        builder.HasOne(p => p.Medicine)
            .WithMany(p => p.MedicineMovements)
            .HasForeignKey(p => p.MedicineId);

        builder.HasOne(p => p.MovementType)
            .WithMany(p => p.MedicineMovements)
            .HasForeignKey(p => p.MovementTypeId);
    }
}