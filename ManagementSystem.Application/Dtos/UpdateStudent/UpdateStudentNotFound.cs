namespace ManagementSystem.Application.Dtos.UpdateStudent;

public record UpdateStudentNotFound(string Message = "Student for which this action was invoked was not found in the database.")
    : UpdateStudentResult;
