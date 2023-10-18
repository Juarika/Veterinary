using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pet");

        builder.Property(p => p.Name)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.BirthDate)
        .HasColumnType("DateTime")
        .IsRequired();

        builder.HasOne(p => p.Owner)
            .WithMany(p => p.Pets)
            .HasForeignKey(p => p.OwnerId);

        builder.HasOne(p => p.Breed)
            .WithMany(p => p.Pets)
            .HasForeignKey(p => p.BreedId);

        builder.HasOne(p => p.Specie)
            .WithMany(p => p.Pets)
            .HasForeignKey(p => p.SpecieId);
    }
}