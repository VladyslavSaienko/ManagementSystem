using ManagementSystem.Domain.Models;
using ManagementSystem.Domain.Repositories.Interfaces;
using ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class TeacherRepository : ITeacherReadOnlyRepository, ITeacherWriteOnlyRepository
{
    private readonly Context _context;

    public TeacherRepository(Context context)
    {
        _context = context;
    }

    public Task<bool> Exists(Guid id) => _context.Teachers.AnyAsync(p => p.Id == id);

    public async Task<Teacher> Get(Guid id)
    {
        var teacherEntity = await _context.Teachers.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);

        return new Teacher(teacherEntity.Id, teacherEntity.NationalIdNumber, teacherEntity.Name, teacherEntity.Surname, teacherEntity.DateOfBirth, teacherEntity.Title, teacherEntity.Number, teacherEntity.Salary);
    }

    public async Task Add(Teacher teacher)
    {
        await _context.Teachers.AddAsync(new()
        {
            NationalIdNumber = teacher.NationalIdNumber,
            Name = teacher.Name,
            Surname = teacher.Surname,
            DateOfBirth = teacher.DateOfBirth,
            Number = teacher.Number,
            Title = teacher.Title,
            Salary = teacher.Salary
        });

        await SaveToDatabase();
    }

    public async Task Delete(Guid teacherId)
    {
        TeacherEntity? teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == teacherId);
        if (teacher is not null)
        {
            _context.Teachers.Remove(teacher);

            await SaveToDatabase();
        }
    }

    public async Task Update(Teacher teacher)
    {
        TeacherEntity teacherEntity = new()
        {
            Id = teacher.Id,
            Name = teacher.Name,
            NationalIdNumber = teacher.NationalIdNumber,
            Surname = teacher.Surname,
            DateOfBirth = teacher.DateOfBirth,
            Number = teacher.Number,
            Title = teacher.Title,
            Salary = teacher.Salary
        };

        var teacherEntry = _context.Entry(teacherEntity);
        _context.Teachers.Update(teacherEntry.Entity);

        await SaveToDatabase();
    }

    private async Task SaveToDatabase()
    {
        await _context.SaveChangesAsync();
    }
}
