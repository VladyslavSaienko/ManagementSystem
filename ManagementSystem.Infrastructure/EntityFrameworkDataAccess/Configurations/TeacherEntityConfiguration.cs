using ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Configurations;

public class TeacherEntityConfiguration : IEntityTypeConfiguration<TeacherEntity>
{
    private const int NameLength = 50;
    private const int NumberLength = 50;

    public void Configure(EntityTypeBuilder<TeacherEntity> builder)
    {
        builder.ToTable("Teachers").HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(NameLength);
        builder.Property(p => p.Surname).IsRequired().HasMaxLength(NameLength);
        builder.Property(p => p.NationalIdNumber).IsRequired().HasMaxLength(NumberLength);
        builder.Property(p => p.Number).IsRequired().HasMaxLength(NumberLength);

        builder.Property(p => p.Title)
            .HasConversion(new EnumToStringConverter<Domain.Enums.Title>());
    }
}
