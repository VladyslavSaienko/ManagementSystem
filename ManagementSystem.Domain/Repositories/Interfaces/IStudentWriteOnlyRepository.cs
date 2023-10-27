using ManagementSystem.Domain.Models;

namespace ManagementSystem.Domain.Repositories.Interfaces;

public interface IStudentWriteOnlyRepository
{
    Task Add(Student student);

    Task Delete(Guid student);

    Task Update(Student student);
}
