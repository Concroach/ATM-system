using Lab5.Application.Contracts.Admin;
using Lab5.Application.Contracts.Admin.Registration;
using Lab5.Presentation.WebAPI.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Presentation.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IAdminLoginService _adminLoginService;
    private readonly IUserRegistration _userRegistration;

    public AdminController(IAdminLoginService adminLoginService, IUserRegistration userRegistration)
    {
        _adminLoginService = adminLoginService;
        _userRegistration = userRegistration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> AdminLogin([FromBody] AdminLoginRequest request)
    {
        var loginResult = await _adminLoginService.Login(request.Password);

        if (loginResult is AdminLoginResult.Failure failure)
        {
            return BadRequest(failure.Message);
        }

        return Ok("Admin login successful");
    }

    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var result = await _userRegistration.RegistrateUser(request.Name, request.PinCode);

        if (result is UserRegistrationResult.Failure failure)
        {
            return BadRequest(failure.Message);
        }

        return Ok("User created successfully");
    }
}