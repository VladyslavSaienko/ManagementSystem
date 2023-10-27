using ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Configurations;

public class StudentEntityConfiguration : IEntityTypeConfiguration<StudentEntity>
{
    private const int NameLength = 50;
    private const int NumberLength = 50;

    public void Configure(EntityTypeBuilder<StudentEntity> builder)
    {
        builder.ToTable("Students").HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(NameLength);
        builder.Property(p => p.Surname).IsRequired().HasMaxLength(NameLength);
        builder.Property(p => p.Number).IsRequired().HasMaxLength(NumberLength);
    }
}
