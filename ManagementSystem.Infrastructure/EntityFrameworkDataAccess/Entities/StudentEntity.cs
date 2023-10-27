namespace ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Entities;

public class StudentEntity
{
    public Guid Id { get; set; }
    public string NationalIdNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Number { get; set; }

    public StudentEntity()
    {
        
    }
}
