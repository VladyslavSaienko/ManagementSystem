using ManagementSystem.Application.Dtos.Results.DeleteStudent;

namespace ManagementSystem.Application.Commands.DeleteStudent;

public interface IDeleteStudent
{
    Task<DeleteStudentResult> Execute(Guid studentId);
}
