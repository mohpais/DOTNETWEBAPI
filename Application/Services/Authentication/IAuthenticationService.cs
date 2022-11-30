using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Record;

namespace Application.Services.Authentication
{
  public interface IAuthenticationService
  {
    // Task<LoginResult> doLogin(string email, string password); IActionResult
    Task<LoginResult> doLoginAsync(string us);
    RegisterResult doRegist(string firtname, string lastname, string email, string password);
  }
}