using ManagementSystem.Domain.Models;

namespace ManagementSystem.Domain.Repositories.Interfaces;

public interface ITeacherReadOnlyRepository
{
    Task<bool> Exists(Guid id);
    Task<Teacher> Get(Guid id);
}
