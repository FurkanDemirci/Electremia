using System;
using System.Collections.Generic;
using System.Text;

namespace Electremia.Dal
{
    /// <summary>
    /// CRUD operations.
    /// </summary>
    internal interface IRepository<in T> where T : class 
    {
        object GetByID(int id);
        bool Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
