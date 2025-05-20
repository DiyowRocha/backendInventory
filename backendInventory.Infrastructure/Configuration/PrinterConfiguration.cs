using backendInventory.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backendInventory.Infrastructure.Configuration;

public class PrinterConfiguration : IEntityTypeConfiguration<Printer>
{
    public void Configure(EntityTypeBuilder<Printer> builder)
    {
        builder.ToTable("Printers");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.SerialNumber).HasMaxLength(100);
        builder.Property(p => p.IPAddress).HasMaxLength(50);
        builder.Property(p => p.PrintQueue).HasMaxLength(100);

        builder.HasOne(p => p.Manufacturer)
            .WithMany()
            .HasForeignKey(p => p.ManufacturerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Model)
            .WithMany(m => m.Printers)
            .HasForeignKey(p => p.ModelId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Unit)
            .WithMany()
            .HasForeignKey(p => p.UnitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Building)
            .WithMany()
            .HasForeignKey(p => p.BuildingId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Department)
            .WithMany(d => d.Printers)
            .HasForeignKey(p => p.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}