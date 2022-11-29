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
    List<User> GetAllUsers();
    Task<User> GetUserByEmail(string email);
  }
}