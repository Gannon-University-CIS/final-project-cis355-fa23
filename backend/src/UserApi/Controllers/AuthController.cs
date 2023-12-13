using Microsoft.AspNetCore.Mvc;
using UserApi.Authorization;
using UserApi.Models;
using UserApi.Services;

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Role = RoleNames.twoFA)] //Added for 2FA
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthenticateRequest model)
    {
        var response = await _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    // add method to accept jwt w/ 2fa token in body
    // add model for twofarequest.cs (token)
    // add model for twofaresponse.cs (jwt token)    
    [HttpPost("2fa")]
    public async Task<IActionResult> twoFA(twoFArequest model)
    {
        var response = await _userService.twoFAService(model);

        if (response == null)
            return BadRequest(new { message = "Invalid token or 2FA request" });
        //added
        //var jwtToken = _jwtUtils.GenerateJwtToken(response);

        //return Ok(new { token = jwtToken });
        return Ok(response);
    }


}
