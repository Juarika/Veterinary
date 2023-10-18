using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class LaboratoryConfiguration : IEntityTypeConfiguration<Laboratory>
{
    public void Configure(EntityTypeBuilder<Laboratory> builder)
    {
        builder.ToTable("laboratory");

        builder.Property(p => p.Name)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.Direction)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.Phone)
        .HasMaxLength(30)
        .IsRequired();
    }
}