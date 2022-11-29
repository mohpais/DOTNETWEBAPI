using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Common
{
  public abstract class BaseEntity<T>
  {
    [Key]
    public virtual T Id { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
  }
}