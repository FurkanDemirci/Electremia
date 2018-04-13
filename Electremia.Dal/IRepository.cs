using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Electremia.Dal
{
    /// <summary>
    /// CRUD operations.
    /// </summary>
    internal interface IRepository<in T> where T : class 
    {
        SqlConnection ConnectionString { get; set; }
        object GetByID(int id);
        bool Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
