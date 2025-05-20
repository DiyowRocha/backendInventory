using backendInventory.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backendInventory.Infrastructure.Configuration;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Name).HasMaxLength(100);

        builder.HasOne(m => m.Manufacturer)
            .WithMany(man => man.Models)
            .HasForeignKey(m => m.ManufacturerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}