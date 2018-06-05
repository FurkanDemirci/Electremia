using Electremia.Dal.Interfaces;
using Electremia.Model.Models;
using System;
using System.Collections.Generic;

namespace Electremia.Dal.Memory
{
    public class LikeMemoryContext : ILikeRepository
    {
        public Like GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Like entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Like entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Like entity)
        {
            throw new NotImplementedException();
        }

        public List<int> GetAll(int id, int type)
        {
            throw new NotImplementedException();
        }
    }
}