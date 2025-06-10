namespace PrimerMicroServicio.Domain.Exceptions;

public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException() : base("Incorrect credentials"){}
    public InvalidCredentialsException(string message) : base(message){}
}