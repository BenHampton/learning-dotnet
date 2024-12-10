using api.Dto.Register;
using api.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller;

[Route("api/accounts")]
[ApiController]
public class AccountController : ControllerBase
{
    
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _accountService.FindLoginUser(loginDto);
        
        if (user == null)
        {
            return Unauthorized("Invalid username and/or password");
        }
        
        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _accountService.RegisterUser(registerDto);

            if (user == null)
            {
                StatusCode(500);
            }

            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}