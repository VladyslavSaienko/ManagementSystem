namespace ManagementSystem.Application.Dtos.Results.GetTeacher;

public record GetTeacherNotFound(string Message = "Teacher for which this action was invoked was not found in the database.")
    : GetTeacherResult;