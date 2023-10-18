using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;   

public class VeterinarianConfiguration : IEntityTypeConfiguration<Veterinarian>
{
    public void Configure(EntityTypeBuilder<Veterinarian> builder)
    {
        builder.ToTable("veterinarian");

        builder.Property(p => p.Name)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.Email)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.Phone)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.Specialty)
        .HasMaxLength(255)
        .IsRequired();
    }
}