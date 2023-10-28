using ManagementSystem.Application.Dtos.Results.DeleteTeacher;

namespace ManagementSystem.Application.Commands.DeleteTeacher;

public interface IDeleteTeacher
{
    Task<DeleteTeacherResult> Execute(Guid teacherId);
}
