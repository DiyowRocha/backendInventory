using backendInventory.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backendInventory.Infrastructure.Configuration;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name).HasMaxLength(100);

        builder.HasOne(d => d.Building)
            .WithMany(b => b.Departments)
            .HasForeignKey(d => d.BuildingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}