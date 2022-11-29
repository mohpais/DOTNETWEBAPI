using Application.Common.Interfaces;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
  public class ApplicationDBContext : DbContext, IApplicationDBContext
  {
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
      : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<AppSetting> AppSettings { get; set; }

    public Task<int> SaveChangesAsync()
    {
      return base.SaveChangesAsync();
    }
  }
}