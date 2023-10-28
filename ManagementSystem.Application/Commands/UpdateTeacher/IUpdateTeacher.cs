using ManagementSystem.Application.Dtos.Results.UpdateTeacher;

namespace ManagementSystem.Application.Commands.UpdateTeacher;

public interface IUpdateTeacher
{
    Task<UpdateTeacherResult> Execute(UpdateTeacherCommand dto);
}
