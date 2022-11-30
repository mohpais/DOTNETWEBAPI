using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Common;
using Application.Record;

namespace Application.Repositories
{
  public interface IUserRepository : IBaseRepository<User>
  {
    Task<User> GetUserByEmailAsync(string email);
  }
}