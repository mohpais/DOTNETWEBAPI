using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public class UserRole : BaseEntity<int>
  {
    [ForeignKey("User")]
    public int UserId { get; set; }
    public virtual User? User { get; set; }

    [ForeignKey("Role")]
    public int RoleId { get; set; }
    public virtual Role? Role { get; set; }
  }
}