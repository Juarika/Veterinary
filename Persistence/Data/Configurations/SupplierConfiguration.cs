using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("supplier");

        builder.Property(p => p.Name)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.Direction)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.Phone)
        .HasMaxLength(255)
        .IsRequired();
    }
}