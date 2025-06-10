using PrimerMicroServicio.Domain.Entities;

namespace PrimerMicroServicio.Application.DTOs;

public class UserDto
{
    public Guid IdUser { get; set; }
    public string UserLongName{ get; set; }
    public string UserEmail { get; set; }

    public static UserDto FromEntity(User user)
    {
        return new UserDto
        {
            IdUser = user.IdUser,
            UserLongName = $"{user.UserFirstName} {user.UserLastName}",
            UserEmail = user.UserEmail
        };
    }
}