using ManagementSystem.Application.Dtos.Requests;
using ManagementSystem.Application.Dtos.Results.ListStudents;

namespace ManagementSystem.Application.Queries;

public interface IListStudents
{
    Task<ListStudentsResult> Execute(SearchStudents request);
}
