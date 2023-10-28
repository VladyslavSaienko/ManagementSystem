using ManagementSystem.Application.Dtos.Results.GetTeacher;

namespace ManagementSystem.Application.Queries;

public interface IGetTeacher
{
    Task<GetTeacherResult> Execute(Guid id);
}
