using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class MedicalTreatmentsConfiguration : IEntityTypeConfiguration<MedicalTreatments>
{
    public void Configure(EntityTypeBuilder<MedicalTreatments> builder)
    {
        builder.ToTable("medicalTreatments");

        builder.Property(p => p.Dose)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.AdministrationDate)
        .HasColumnType("DateTime")
        .IsRequired();

        builder.Property(p => p.Observation)
        .HasMaxLength(255)
        .IsRequired();

        builder.HasOne(p => p.Appointment)
            .WithMany(p => p.MedicalTreatments)
            .HasForeignKey(p => p.AppointmentId);

        builder.HasOne(p => p.Medicine)
            .WithMany(p => p.MedicalTreatments)
            .HasForeignKey(p => p.MedicineId);
    }
}