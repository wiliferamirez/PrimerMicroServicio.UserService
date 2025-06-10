namespace PrimerMicroServicio.Application.DTOs;

public class RegisterUserDto
{
    public string CedulaUser { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string UserPasswordHash { get; set; }
    public string UserEmail { get; set; }
}