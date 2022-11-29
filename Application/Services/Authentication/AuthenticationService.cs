using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Record;
using System.Text.Json;

namespace Application.Services.Authentication
{
  public class AuthenticationService : IAuthenticationService
  {
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IEncryption _encryption;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IEncryption encryption)
    {
      _jwtTokenGenerator = jwtTokenGenerator;
      _encryption = encryption;
    }

    public class LoginData
    {
        public string? email { get; set; }
        public string? password  { get; set; }
    }

    public async Task<LoginResult> doLogin(string us)
    {
      string chars = _encryption.Countchar(us);
      string en = us + chars;
      // var token = _jwtTokenGenerator.GenerateToken(1, enc, "test@email.com");
      var _params = await _encryption.base64ToString(en);
      LoginData loginData = JsonSerializer.Deserialize<LoginData>(_params);
      
      var hashing = _encryption.Hash(loginData.password);

      return new LoginResult(loginData.email, loginData.password, hashing);
    }

    public RegisterResult doRegist(string firtname, string lastname, string email, string password)
    {
      return new RegisterResult(firtname, lastname, email, password);
    }
  }
}