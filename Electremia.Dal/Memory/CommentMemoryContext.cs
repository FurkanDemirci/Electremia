using Electremia.Dal.Interfaces;
using Electremia.Model.Models;
using System;
using System.Collections.Generic;

namespace Electremia.Dal.Memory
{
    public class CommentMemoryContext : ICommentRepository
    {
        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Comment entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Comment entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Comment entity)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll(int id, int type)
        {
            throw new NotImplementedException();
        }
    }
}