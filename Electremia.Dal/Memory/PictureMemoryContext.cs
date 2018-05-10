using System;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Memory
{
    public class PictureMemoryContext : IRepository<Picture>
    {
        public Picture GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Picture entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Picture entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Picture entity)
        {
            throw new NotImplementedException();
        }
    }
}