using ManagementSystem.Application.Dtos.DeleteTeacher;

namespace ManagementSystem.Application.Commands.DeleteTeacher;

public interface IDeleteTeacher
{
    Task<DeleteTeacherResult> Execute(Guid teacherId);
}
