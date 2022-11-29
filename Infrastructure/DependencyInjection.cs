using Application.Common.Interfaces;
using Application.Repositories;
using Infrastructure.Common.Models;
using Infrastructure.Common.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(
      this IServiceCollection services, 
      IConfiguration configuration
    )
    {

      services.AddDbContext<ApplicationDBContext>(
        options =>
          options.UseNpgsql(
            configuration.GetConnectionString("WebApiDatabase"),
            b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)));

      services.Configure<ConfigSettings>(configuration.GetSection(ConfigSettings.SectionName));
      services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
      services.AddSingleton<IEncryption, Encryption>();
      services.AddScoped<IApplicationDBContext>(provider => provider.GetService<ApplicationDBContext>());
      services.AddScoped<IUserRepository, UserRepository>();

      return services;
    }
  }
}