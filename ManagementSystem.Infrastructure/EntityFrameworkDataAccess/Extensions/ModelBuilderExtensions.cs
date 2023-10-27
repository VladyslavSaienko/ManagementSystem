using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Extensions;

public static class ModelBuilderExtensions
{
    public static void ConvertEnumsToStrings(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType.IsEnum)
                {
                    var targetType = typeof(Converters.EnumToStringConverter<>).MakeGenericType(property.ClrType);
                    var converter = Activator.CreateInstance(targetType);

                    property.SetValueConverter((ValueConverter)converter);
                }
            }
        }
    }
}
