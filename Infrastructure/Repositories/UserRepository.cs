using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Record;
using Application.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly ApplicationDBContext _applicationDBContext;

    public UserRepository(ApplicationDBContext applicationDBContext)
    {
      _applicationDBContext = applicationDBContext;
    }

    public async Task<User> Create(User entity)
    {
      try
      {
        if (entity is not null)
        {
          var obj = _applicationDBContext.Add < User > (entity);
          await _applicationDBContext.SaveChangesAsync();

          return obj.Entity;
        }
        return null;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public User GetById(int id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<User> ListAll()
    {
      var users = _applicationDBContext.Users.ToList();
      return users;
    }

    public void Remove(User entity)
    {
      throw new NotImplementedException();
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
      var users = await _applicationDBContext.Users.Where<User>(x => x.Email == email).FirstOrDefaultAsync();

      return users;
    }
  }
}