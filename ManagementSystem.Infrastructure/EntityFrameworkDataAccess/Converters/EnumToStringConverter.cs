using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Converters;

public class EnumToStringConverter<TEnum> : ValueConverter<TEnum, string>
{
    public EnumToStringConverter() : base(
        v => v.ToString()!,
        v => (TEnum)Enum.Parse(typeof(TEnum), v)
    )
    { }
}
