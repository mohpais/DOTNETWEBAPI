using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
  public interface IJwtTokenGenerator
  {
    string GenerateToken(int userId, string fullName, string email);
  }
}