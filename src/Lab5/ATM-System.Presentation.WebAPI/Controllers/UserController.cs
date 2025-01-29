using Lab5.Application.Contracts.User;
using Lab5.Presentation.WebAPI.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Presentation.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var loginResult = await _userService.Login(request.Name, request.PinCode);

        if (loginResult is UserLoginResult.Failure failure)
        {
            return BadRequest(failure.Message);
        }

        return Ok("Login successful");
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        return Ok("Logout successful");
    }

    [HttpGet("balance")]
    public async Task<IActionResult> GetBalance()
    {
        var balanceResult = await _userService.GetBalance();

        if (balanceResult is UserOperationResult.Failure failure)
        {
            return BadRequest(failure.Message);
        }

        if (balanceResult is UserOperationResult.Money money)
        {
            return Ok(new { Balance = money.Amount });
        }

        return BadRequest("Unknown error");
    }

    [HttpPost("replenish")]
    public async Task<IActionResult> Replenish([FromBody] float amount)
    {
        if (amount < 0)
        {
            return BadRequest("Amount cannot be negative");
        }

        var result = await _userService.ChangeAccount(amount);

        if (result is UserOperationResult.Failure failure)
        {
            return BadRequest(failure.Message);
        }

        return Ok("Replenishment successful");
    }

    [HttpPost("withdraw")]
    public async Task<IActionResult> Withdraw([FromBody] float amount)
    {
        if (amount < 0)
        {
            return BadRequest("Amount cannot be negative");
        }

        var result = await _userService.ChangeAccount(-amount);

        if (result is UserOperationResult.Failure failure)
        {
            return BadRequest(failure.Message);
        }

        return Ok("Withdrawal successful");
    }

    [HttpGet("operations")]
    public async Task<IActionResult> GetOperations()
    {
        var result = await _userService.GetUserOperations();

        if (result is UserOperationResult.Failure failure)
        {
            return BadRequest(failure.Message);
        }

        if (result is UserOperationResult.UserOperations operations)
        {
            return Ok(operations.Operations);
        }

        return BadRequest("Unknown error");
    }
}