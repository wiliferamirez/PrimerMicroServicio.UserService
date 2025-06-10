using Microsoft.AspNetCore.Mvc;
using PrimerMicroServicio.Application.DTOs;
using PrimerMicroServicio.Application.Interfaces;

namespace PrimerMicroServicio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
    {
        var succes = await _userService.RegisterUserAsync(dto);
        if(!succes)
            return Conflict(("User already exists"));
        return Ok("User created successfully");
    }
    
    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] LoginUserDto dto)
    {
        var user = await _userService.AuthenticateUserAsync(dto.UserEmail, dto.UserPassword);
        if (user is null)
            return Unauthorized("User doesnt exist");

        return Ok(user);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }
}