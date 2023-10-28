using ManagementSystem.Application.Dtos.Requests;
using ManagementSystem.Application.Dtos.Results.ListTeachers;

namespace ManagementSystem.Application.Queries;

public interface IListTeachers
{
    Task<ListTeachersResult> Execute(SearchTeachers request);
}
