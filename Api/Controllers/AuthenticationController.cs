using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Authentication;
using Contracts.Request.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [ApiController]
  [Route("auth")]
  public class AuthenticationController : ControllerBase
  {
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
      _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
      var login = _authenticationService.doLogin(request.us);

      return Ok(login);
    }


    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
      return Ok(request);
    }
  }
}