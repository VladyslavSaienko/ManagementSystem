namespace ManagementSystem.Infrastructure.Exceptions;

public class InfrastructureException : Exception
{
    public InfrastructureException(string businessMessage)
           : base(businessMessage)
    {
    }
}
