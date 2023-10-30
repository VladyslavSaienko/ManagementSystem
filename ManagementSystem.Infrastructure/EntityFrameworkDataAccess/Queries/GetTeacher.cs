using ManagementSystem.Application.Dtos.Results.GetTeacher;
using ManagementSystem.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Queries;

public class GetTeacher : IGetTeacher
{
    private readonly Context _ctx;

    public GetTeacher(Context ctx)
    {
        _ctx = ctx;
    }

    public async Task<GetTeacherResult> Execute(Guid id)
    {
        var entity = await _ctx.Teachers
            .AsNoTracking()
            .SingleOrDefaultAsync(c=>c.Id == id);

        if (entity is null)
            return new GetTeacherNotFound();

        return new GetTeacherSuccess(
            entity.Id,
            entity.NationalIdNumber,
            entity.Name,
            entity.Surname,
            entity.Number,
            entity.DateOfBirth,
            entity.Title.ToString(),
            entity.Salary);
    }
}
