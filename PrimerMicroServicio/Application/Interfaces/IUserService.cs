using PrimerMicroServicio.Application.DTOs;

namespace PrimerMicroServicio.Application.Interfaces;

public interface IUserService
{
    Task<bool> RegisterUserAsync (RegisterUserDto newUser);
    Task<UserDto> AuthenticateUserAsync (string email, string password);
    Task<List<UserDto>> GetAllUsersAsync();
}