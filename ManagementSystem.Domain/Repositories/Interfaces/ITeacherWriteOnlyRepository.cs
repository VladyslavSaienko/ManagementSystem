using ManagementSystem.Domain.Models;

namespace ManagementSystem.Domain.Repositories.Interfaces;

public interface ITeacherWriteOnlyRepository
{
    Task Add(Teacher teacher);

    Task Delete(Guid teacherId);

    Task Update(Teacher teacher);
}
