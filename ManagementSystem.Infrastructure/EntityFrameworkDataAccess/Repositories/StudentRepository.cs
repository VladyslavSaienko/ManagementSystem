using ManagementSystem.Domain.Models;
using ManagementSystem.Domain.Repositories.Interfaces;
using ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class StudentRepository : IStudentReadOnlyRepository, IStudentWriteOnlyRepository
{
    private readonly Context _context;

    public StudentRepository(Context context)
    {
        _context = context;
    }

    public Task<bool> Exists(Guid id) => _context.Students.AnyAsync(p => p.Id == id);

    public async Task<Student> Get(Guid id)
    {
        var studentEntity = await _context.Students.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);

        return new Student(studentEntity.Id, studentEntity.NationalIdNumber, studentEntity.Name, studentEntity.Surname, studentEntity.DateOfBirth, studentEntity.Number);
    }

    public async Task Add(Student student)
    {
        await _context.Students.AddAsync(new()
        {
            Name = student.Name,
            NationalIdNumber = student.NationalIdNumber,
            Surname = student.Surname,
            DateOfBirth = student.DateOfBirth,
            Number = student.Number
        });

        await SaveToDatabase();
    }

    public async Task Delete(Guid studentId)
    {
        StudentEntity? student = await _context.Students.FirstOrDefaultAsync(x => x.Id == studentId);
        if (student is not null)
        {
            _context.Students.Remove(student);

            await SaveToDatabase();
        }
    }

    public async Task Update(Student student)
    {
        StudentEntity studentEntity = new()
        {
            Id = student.Id,
            Name = student.Name,
            NationalIdNumber = student.NationalIdNumber,
            Surname = student.Surname,
            DateOfBirth = student.DateOfBirth,
            Number = student.Number
        };

        var studentEntry = _context.Entry(studentEntity);
        _context.Students.Update(studentEntry.Entity);

        await SaveToDatabase();
    }

    private async Task SaveToDatabase()
    {
        await _context.SaveChangesAsync();
    }
}
