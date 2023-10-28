using ManagementSystem.Application.Dtos.Requests;
using ManagementSystem.Application.Dtos.Results.ListStudents;
using ManagementSystem.Application.Queries;
using ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Queries;

public class ListStudents : IListStudents
{
    private readonly Context _ctx;

    public ListStudents(Context ctx)
    {
        _ctx = ctx;
    }

    public async Task<ListStudentsResult> Execute(SearchStudents request)
    {
        var offset = (request.Page - 1) * request.ItemsPerPage;
        var totalCount = 0;

        var items = await GetQuery();
        var result = new ListStudentsResultSuccess(items, totalCount);

        return result;

        Task<List<StudentListItem>> GetQuery()
        {
            var query = GetFilteredQuery(request);

            var queryTask = query
                .Skip(offset)
                .Take(request.ItemsPerPage)
                .Select(p => new StudentListItem(
                        p.Id,
                        p.NationalIdNumber,
                        p.Name,
                        p.Surname,
                        p.Number,
                        p.DateOfBirth
                        ))
                .ToListAsync();

            return queryTask;
        }

        IQueryable<StudentEntity> GetFilteredQuery(SearchStudents request)
        {
            var query = _ctx.Students;

            totalCount = query.Count();

            return query;
        }
    }
}
