using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Users;
using Contracts.Request;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
  [ApiController]
  [Route("user")]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet("list")]
    public ActionResult<IList<User>> List()
    {
      return Ok(_userService.ListAll());
    }

    [HttpPost("create")]
    public async Task < IActionResult > Create(UserRequest request)
    {
      User user = new User{
        FullName=request.FullName,
        UserName=request.UserName,
        Email=request.Email,
        Password=request.Password
      };

      var response = await _userService.Create(user);
      return Ok();
    }

    [HttpGet("detail")]
    public async Task < IActionResult > Get()
    {

      var response = await _userService.GetUserByEmailAsync("mohamad.pais30@gmail.com");
      return Ok(response);
    }

    // [HttpGet("detail")]
    // public async Task<IActionResult> GetAsync()
    // {
    //   var users = await _applicationDBContext.Users.ToListAsync();

    //   return Ok(users);
    // }
  }
}