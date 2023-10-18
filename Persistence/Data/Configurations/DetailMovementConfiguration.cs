using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class DetailMovementConfiguration : IEntityTypeConfiguration<DetailMovement>
{
    public void Configure(EntityTypeBuilder<DetailMovement> builder)
    {
        builder.ToTable("detailMovement");

        builder.Property(p => p.Quantity)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.Price)
        .HasColumnType("decimal")
        .IsRequired();

        builder.HasOne(p => p.Medicine)
            .WithMany(p => p.DetailMovements)
            .HasForeignKey(p => p.MedicineId);

        builder.HasOne(p => p.MedicineMovement)
            .WithMany(p => p.DetailMovements)
            .HasForeignKey(p => p.MedicineMovementId);
    }
}