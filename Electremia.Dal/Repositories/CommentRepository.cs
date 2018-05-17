using System;
using System.Collections.Generic;
using Electremia.Dal.Interfaces;
using Electremia.Dal.Memory;
using Electremia.Dal.Sql;
using Electremia.Model.Models;

namespace Electremia.Dal.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(IRepository<Comment> context) : base(context)
        {
        }

        private ICommentRepository RightContext()
        {
            switch (Context)
            {
                case CommentSqlContext context:
                    return context;
                case CommentMemoryContext context:
                    return context;
                default:
                    throw new NotImplementedException();
            }
        }

        public List<Comment> GetAll(int id, int type)
        {
            return RightContext().GetAll(id, type);
        }
    }
}