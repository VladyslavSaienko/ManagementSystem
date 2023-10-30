using ManagementSystem.Infrastructure.EntityFrameworkDataAccess;
using ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.IntegrationTests.Fixtures;

internal class StudentFixture
{
    private readonly Context _context;

    public Context Context { get { return _context; } }

    public StudentFixture(Context context)
    {
        _context = context;
    }

    public List<StudentEntity> GenerateTestStudents()
    {
        return new List<StudentEntity>()
        {
            new StudentEntity()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                NationalIdNumber = "ID12345",
                Name = "John",
                Surname = "Doe",
                Number = "TJ8",
                DateOfBirth = new DateOnly(2004, 4, 15)
            },
            new StudentEntity()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                NationalIdNumber = "ID12346",
                Name = "Jane",
                Surname = "Doe",
                Number = "UR4",
                DateOfBirth = new DateOnly(2008, 4, 15)
            }
        };
    }

    public void SaveStudents(IEnumerable<StudentEntity> students)
    {
        _context.Students.AddRange(students);
        _context.SaveChanges();
    }

    public List<StudentEntity> GetAllStudents()
    {
        return _context.Students.AsNoTracking().ToList();
    }
}
