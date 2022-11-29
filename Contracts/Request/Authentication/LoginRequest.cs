using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Request.Authentication
{
  public record LoginRequest(
    // string Email,
    // string Password
    string us,
    string ps
  );
}