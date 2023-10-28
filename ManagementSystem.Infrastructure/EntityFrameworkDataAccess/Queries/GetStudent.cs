using ManagementSystem.Application.Dtos.Results.GetStudent;
using ManagementSystem.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Queries;

public class GetStudent : IGetStudent
{
    private readonly Context _ctx;

    public GetStudent(Context ctx)
    {
        _ctx = ctx;
    }

    public async Task<GetStudentResult> Execute(Guid id)
    {
        var entity = await _ctx.Students
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Id == id);

        if (entity is null)
            return new GetStudentNotFound();

        return new GetStudentSuccess(
            entity.Id,
            entity.NationalIdNumber,
            entity.Name,
            entity.Surname,
            entity.Number,
            entity.DateOfBirth);
    }
}
