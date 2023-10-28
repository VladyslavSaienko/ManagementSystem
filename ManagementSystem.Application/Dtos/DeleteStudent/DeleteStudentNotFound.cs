namespace ManagementSystem.Application.Dtos.DeleteStudent;

public record DeleteStudentNotFound(string Message = "Student for which this action was invoked was not found in the database.") 
    : DeleteStudentResult;
