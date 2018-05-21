using System;
using System.Collections.Generic;
using System.Text;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Memory
{
    public class PostMemoryContext : IPostRepository
    {
        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        int IPostRepository.Add(Post entity)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCountByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Post entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Post entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
