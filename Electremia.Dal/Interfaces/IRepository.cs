using System;
using System.Collections.Generic;
using System.Text;

namespace Electremia.Dal.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
