namespace ManagementSystem.Application.Dtos.Results.UpdateTeacher
{
    public record UpdateTeacherFailed(string Message = "Failed to delete teacher")
        : UpdateTeacherResult;
}
