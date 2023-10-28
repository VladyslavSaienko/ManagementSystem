using ManagementSystem.Domain.Models;

namespace ManagementSystem.Domain.Repositories.Interfaces;

public interface IStudentReadOnlyRepository
{
    Task<bool> Exists(Guid id);
    Task<Student> Get(Guid id);
}
