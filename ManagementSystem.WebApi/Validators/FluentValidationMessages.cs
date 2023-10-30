namespace ManagementSystem.WebApi.Validators;

internal static class FluentValidationMessages
{
    internal const string NotEmptyMessage = "Field is required.";
    internal const string NotValidStudentAgeMessage = "Age may not be more than 22.";
    internal const string NotValidTeacherAgeMessage = "Age may not be less than 21.";
    internal const string NotValidTeacherTitleMessage = "Title can be either Mr, Mrs, Miss, Dr, Prof";
}
