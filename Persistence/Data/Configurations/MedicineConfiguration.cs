using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
{
    public void Configure(EntityTypeBuilder<Medicine> builder)
    {
        builder.ToTable("medicine");

        builder.Property(p => p.Name)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.QuantityAvailable)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.Price)
        .HasColumnType("decimal")
        .IsRequired();

        builder.HasOne(p => p.Laboratory)
            .WithMany(p => p.Medicines)
            .HasForeignKey(p => p.LaboratoryId);

        builder
           .HasMany(m => m.Suppliers)
            .WithMany(s => s.Medicines)
            .UsingEntity<MedicineSupplier>(
                j => j
                    .HasOne(pt => pt.Supplier)
                    .WithMany(t => t.MedicineSuppliers)
                    .HasForeignKey(ut => ut.SupplierId),
                j => j
                    .HasOne(et => et.Medicine)
                    .WithMany(et => et.MedicineSuppliers)
                    .HasForeignKey(el => el.MedicineId),
                j =>
                {
                    j.ToTable("MedicineSuppliers");
                    j.HasKey(t => new { t.MedicineId, t.SupplierId });
                });
                
    }
}