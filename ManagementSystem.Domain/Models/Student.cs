namespace ManagementSystem.Domain.Models;

public class Student : Person
{
    public string Number { get; set; }

    public Student(
        Guid id,
        string nationalIdNumber,
        string name,
        string surname,
        DateTime dateOfBirth,
        string number) : base(id, nationalIdNumber, name, surname, dateOfBirth)
    {
        Number = number;
    }
}
