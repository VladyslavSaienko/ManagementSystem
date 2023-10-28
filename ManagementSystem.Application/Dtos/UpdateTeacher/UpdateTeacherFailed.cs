namespace ManagementSystem.Application.Dtos.UpdateTeacher
{
    public record UpdateTeacherFailed(string Message = "Failed to delete teacher") 
        : UpdateTeacherResult;
}
