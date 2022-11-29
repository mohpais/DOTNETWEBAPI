using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public class User : BaseEntity<int>
  {
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string? PhoneNo { get; set; }
    public string Password { get; set; }
    public string? Token { get; set; }
    public bool IsActive { get; set; } = true;
  }
}