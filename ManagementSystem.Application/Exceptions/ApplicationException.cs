﻿namespace ManagementSystem.Application.Exceptions;

public class ApplicationException : Exception
{
    public ApplicationException(string businessMessage)
           : base(businessMessage)
    {
    }
}
