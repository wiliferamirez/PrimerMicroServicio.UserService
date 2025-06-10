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
}