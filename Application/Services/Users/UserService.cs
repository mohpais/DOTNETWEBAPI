using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Record;
using Application.Repositories;
using Domain.Entities;

namespace Application.Services.Users
{
  public class UserService : IUserService
  {

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }
    
    public async Task<User> Create(User entity)
    {
      return await _userRepository.Create(entity);
    }

    public User GetById(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
      return await _userRepository.GetUserByEmailAsync(email);
    }

    public IEnumerable<User> ListAll()
    {
      throw new NotImplementedException();
    }

    public void Remove(User entity)
    {
      throw new NotImplementedException();
    }
  }
}