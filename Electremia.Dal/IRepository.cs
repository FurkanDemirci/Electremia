using System;
using System.Collections.Generic;
using System.Text;

namespace Electremia.Dal
{
    /// <summary>
    /// CRUD operations.
    /// </summary>
    interface IRepository
    {
        int GetByID(int id);
        void Add();
        void Update();
        void Delete();
    }
}
