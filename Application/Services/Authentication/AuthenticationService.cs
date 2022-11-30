using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Record;
using System.Text.Json;
using Application.Repositories;
using Domain.Entities;

namespace Application.Services.Authentication
{
  public class AuthenticationService : IAuthenticationService
  {
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IEncryption _encryption;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(
      IJwtTokenGenerator jwtTokenGenerator, 
      IEncryption encryption,
      IUserRepository userRepository)
    {
      _jwtTokenGenerator = jwtTokenGenerator;
      _encryption = encryption;
      _userRepository = userRepository;
    }

    public class LoginData
    {
        public string email { get; set; } = "";
        public string password  { get; set; } = "";
    }

    public async Task<LoginResult> doLoginAsync(string us)
    {
      string chars = _encryption.Countchar(us);
      string en = us + chars;
      var _params = await _encryption.base64ToString(en);
      LoginData? loginData = JsonSerializer.Deserialize<LoginData>(_params);

      if (await _userRepository.GetUserByEmailAsync(loginData.email) is not User user)
      {
        throw new Exception("Email or password not recognize!");
      }

      var hashing = _encryption.Hash(loginData.password);
      if (user.Password != hashing)
      {
        throw new Exception("Email or password not recognize!");
        // return new LoginResult(loginData.email, loginData.password, "", "Please provide from input!");
      }

      var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FullName, user.Email);

      return new LoginResult(user.FullName, user.UserName, user.Email, user.PhoneNo?? "", token);
    }

    public RegisterResult doRegist(string firtname, string lastname, string email, string password)
    {
      return new RegisterResult(firtname, lastname, email, password);
    }
  }
}