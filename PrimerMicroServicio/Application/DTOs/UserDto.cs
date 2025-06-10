using PrimerMicroServicio.Domain.Entities;

namespace PrimerMicroServicio.Application.DTOs;

public class UserDto
{
    public Guid IdUser { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string UserEmail { get; set; }
}