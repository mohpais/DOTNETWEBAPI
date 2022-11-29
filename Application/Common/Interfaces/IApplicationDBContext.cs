using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
  public interface IApplicationDBContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<AppSetting> AppSettings { get; set; }
    
    Task<int> SaveChangesAsync();

  }
}