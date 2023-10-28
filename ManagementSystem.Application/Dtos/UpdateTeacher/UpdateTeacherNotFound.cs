namespace ManagementSystem.Application.Dtos.UpdateTeacher;

public record UpdateTeacherNotFound(string Message = "Teacher for which this action was invoked was not found in the database.") 
    : UpdateTeacherResult;
