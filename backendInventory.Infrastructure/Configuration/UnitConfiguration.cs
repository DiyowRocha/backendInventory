using backendInventory.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backendInventory.Infrastructure.Configuration;

public class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.ToTable("Units");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name).HasMaxLength(100);
        builder.Property(u => u.Address).HasMaxLength(200);
        builder.Property(u => u.Number).HasMaxLength(10);
        builder.Property(u => u.Neighborhood).HasMaxLength(100);
        builder.Property(u => u.City).HasMaxLength(100);
        builder.Property(u => u.State).HasMaxLength(50);
        builder.Property(u => u.ZipCode).HasMaxLength(20);
    }
}