using ManagementSystem.Application.Dtos.Results.GetStudent;

namespace ManagementSystem.Application.Queries;

public interface IGetStudent
{
    Task<GetStudentResult> Execute(Guid id);
}
