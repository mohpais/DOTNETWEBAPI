using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Request
{
  public record UserRequest(
    string FullName,
    string UserName,
    string Email,
    string Password
  );
}