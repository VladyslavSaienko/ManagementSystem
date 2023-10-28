using ManagementSystem.Application.Dtos.Results.DeleteStudent;

namespace ManagementSystem.Application.Commands.DeleteStudent;

internal interface IDeleteStudent
{
    Task<DeleteStudentResult> Execute(Guid studentId);
}
