using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrimerMicroServicio.Application.DTOs;
using PrimerMicroServicio.Application.Interfaces;
using PrimerMicroServicio.Domain.Entities;
using PrimerMicroServicio.Domain.Exceptions;

namespace PrimerMicroServicio.Application.Services;

public class UserService : IUserService
{  
    private readonly List<User> _users = new();

    public async Task<bool> RegisterUserAsync(RegisterUserDto newUser)
    {
        if (_users.Any(u => u.CedulaUser == newUser.CedulaUser || u.UserEmail == newUser.UserEmail))
        {
            throw new UserAlreadyExistsException();
        }
        var user = new User
        {
            IdUser = Guid.NewGuid(),
            CedulaUser = newUser.CedulaUser,
            UserFirstName = newUser.UserFirstName,
            UserLastName = newUser.UserLastName,
            UserEmail = newUser.UserEmail,
            UserPasswordHash = newUser.UserPasswordHash,
            UserRegisterDate = DateTime.Now,
        };
        _users.Add(user);
        return true;
    }

    public async Task<UserDto> AuthenticateUserAsync(string email, string password)
    {
        var user = _users.FirstOrDefault(u => u.UserEmail == email && u.UserPasswordHash == password);
        if (user is not null)
        {
            return UserDto.FromEntity(user);
        }
        return null;
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        var dtos = _users.Select(UserDto.FromEntity).ToList();
        return await Task.FromResult(_users.Select(UserDto.FromEntity).ToList());
    }
}