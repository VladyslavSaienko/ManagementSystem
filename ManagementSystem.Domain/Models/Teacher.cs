using ManagementSystem.Domain.Enums;

namespace ManagementSystem.Domain.Models;

public class Teacher : Person
{
    public Title Title { get; set; }
    public string Number { get; set; }
    public int? Salary { get; set; }

    public Teacher(
        Guid id, 
        string nationalIdNumber, 
        string name, 
        string surname, 
        DateOnly dateOfBirth, 
        Title title, 
        string number,
        int? salary) : base(id, nationalIdNumber, name, surname, dateOfBirth)
    {
        Title = title;
        Number = number;
        Salary = salary;
    }
}
