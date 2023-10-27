namespace ManagementSystem.Domain.Models;

public abstract class Person : IEntity
{
    public Guid Id { get; set; }
    public string NationalIdNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public Person()
    {
    }

    protected Person(Guid id, string nationalIdNumber, string name, string surname, DateOnly dateOfBirth)
    {
        Id = id;
        NationalIdNumber = nationalIdNumber;
        Name = name;
        Surname = surname;
        DateOfBirth = dateOfBirth;
    }
}
