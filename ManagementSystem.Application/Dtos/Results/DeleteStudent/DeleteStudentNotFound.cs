namespace ManagementSystem.Application.Dtos.Results.DeleteStudent;

public record DeleteStudentNotFound(string Message = "Student for which this action was invoked was not found in the database.")
    : DeleteStudentResult;
