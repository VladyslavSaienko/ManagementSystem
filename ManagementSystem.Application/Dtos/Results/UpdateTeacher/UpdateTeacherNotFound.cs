namespace ManagementSystem.Application.Dtos.Results.UpdateTeacher; 
public record UpdateTeacherNotFound(string Message = "Teacher for which this action was invoked was not found in the database.") 
    : UpdateTeacherResult;
