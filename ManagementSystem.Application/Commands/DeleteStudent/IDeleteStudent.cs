using ManagementSystem.Application.Dtos.DeleteStudent;

namespace ManagementSystem.Application.Commands.DeleteStudent;

internal interface IDeleteStudent
{
    Task<DeleteStudentResult> Execute(Guid studentId);
}
