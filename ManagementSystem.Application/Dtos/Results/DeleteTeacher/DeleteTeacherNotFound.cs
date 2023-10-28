namespace ManagementSystem.Application.Dtos.Results.DeleteTeacher
{
    public record DeleteTeacherNotFound(string Message = "Teacher for which this action was invoked was not found in the database.")
        : DeleteTeacherResult;
}
