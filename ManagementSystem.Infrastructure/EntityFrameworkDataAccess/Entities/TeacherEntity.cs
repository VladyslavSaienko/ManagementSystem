using ManagementSystem.Domain.Enums;

namespace ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Entities;

public class TeacherEntity
{
    public Guid Id { get; set; }
    public string NationalIdNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public Title Title { get; set; }
    public string Number { get; set; }
    public int? Salary { get; set; }

    public TeacherEntity()
    {
    }
}
