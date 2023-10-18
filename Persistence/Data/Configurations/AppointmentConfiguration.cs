using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("appointment");

        builder.Property(p => p.Date)
        .HasColumnType("DateTime")
        .IsRequired();

        builder.Property(p => p.Hour)
        .HasColumnType("DateTime")
        .IsRequired();

        builder.Property(p => p.Reason)
        .HasMaxLength(255)
        .IsRequired();

        builder.HasOne(p => p.Veterinarian)
            .WithMany(p => p.Appointments)
            .HasForeignKey(p => p.VeterinarianId);
    }
}