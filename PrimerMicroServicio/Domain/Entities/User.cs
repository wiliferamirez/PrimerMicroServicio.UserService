namespace PrimerMicroServicio.Domain.Entities;

public class User
{
    public string IdUser { get; set; }
    public string CedulaUser { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string UserPasswordHash { get; set; }
    public string UserEmail { get; set; }
    public DateTime UserRegisterDate { get; set; }
}