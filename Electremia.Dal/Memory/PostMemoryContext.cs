using System;
using System.Collections.Generic;
using System.Text;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Memory
{
    public class PostMemoryContext : IRepository<Post>
    {
        public Post GetById(int id)
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

        public Post GetByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
