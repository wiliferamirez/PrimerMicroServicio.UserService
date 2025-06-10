namespace PrimerMicroServicio.Domain.Exceptions;

public class UserAlreadyExistsException : Exception
{
    public UserAlreadyExistsException() : base ("User has already been registered"){}
    public UserAlreadyExistsException(string message) : base(message){}
}