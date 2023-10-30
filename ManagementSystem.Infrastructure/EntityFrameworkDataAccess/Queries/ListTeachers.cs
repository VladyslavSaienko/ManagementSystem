using ManagementSystem.Application.Dtos.Requests;
using ManagementSystem.Application.Dtos.Results.ListTeachers;
using ManagementSystem.Application.Queries;
using ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Queries;

public class ListTeachers : IListTeachers
{
    private readonly Context _ctx;

    public ListTeachers(Context ctx)
    {
        _ctx = ctx;
    }

    public async Task<ListTeachersResult> Execute(SearchTeachers request)
    {
        var offset = (request.Page - 1) * request.ItemsPerPage;
        var totalCount = 0;

        var items = await GetQuery();
        var result = new ListTeachersResultSuccess(items, totalCount);

        return result;

        Task<List<TeacherListItem>> GetQuery()
        {
            var query = GetFilteredQuery(request);

            var queryTask = query
                .Skip(offset)
                .Take(request.ItemsPerPage)
                .Select(p => new TeacherListItem(
                        p.Id,
                        p.NationalIdNumber,
                        p.Name,
                        p.Surname,
                        p.Number,
                        p.DateOfBirth,
                        p.Title.ToString(),
                        p.Salary
                        ))
                .ToListAsync();

            return queryTask;
        }

        IQueryable<TeacherEntity> GetFilteredQuery(SearchTeachers request)
        {
            var query = _ctx.Teachers;

            totalCount = query.Count();

            return query;
        }
    }
}
