using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public class User : BaseEntity<int>
  {
    public string FullName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNo { get; set; } = "";
    public string Password { get; set; } = null!;
    public string? Token { get; set; } = "";
    public bool IsActive { get; set; } = true;
  }
}