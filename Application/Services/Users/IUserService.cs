using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Record;
using Domain.Entities;
using Application.Common;

namespace Application.Services.Users
{
  public interface IUserService : IBaseRepository<User>
  {
    List<User> GetAllUsers();
    Task<User> GetUserByEmail(string email);
  }
}