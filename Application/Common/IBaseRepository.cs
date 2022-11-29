using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common
{
  public interface IBaseRepository<TEntity>
  {
    Task < TEntity > Create(TEntity entity);
    void Remove(TEntity entity);
    IEnumerable< TEntity > ListAll();
    TEntity GetById(int id);
  }
}