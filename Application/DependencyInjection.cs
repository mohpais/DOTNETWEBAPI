using Application.Services.Authentication;
using Application.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
      services.AddScoped<IAuthenticationService, AuthenticationService>();
      services.AddScoped<IUserService, UserService>();

      return services;
    }
  }
}