using backendInventory.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backendInventory.Infrastructure.Configuration;

public class BuildingConfiguration : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.ToTable("Buildings");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name).HasMaxLength(100);
        builder.Property(b => b.Floor).HasConversion<int>();

        builder.HasOne(b => b.Unit)
            .WithMany(u => u.Buildings)
            .HasForeignKey(b => b.UnitId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}