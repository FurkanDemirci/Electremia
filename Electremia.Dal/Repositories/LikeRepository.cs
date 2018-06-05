using Electremia.Dal.Interfaces;
using Electremia.Dal.Memory;
using Electremia.Dal.Sql;
using Electremia.Model.Models;
using System;
using System.Collections.Generic;

namespace Electremia.Dal.Repositories
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        public LikeRepository(IRepository<Like> context) : base(context)
        {
        }

        private ILikeRepository RightContext()
        {
            switch (Context)
            {
                case LikeSqlContext context:
                    return context;
                case LikeMemoryContext context:
                    return context;
                default:
                    throw new NotImplementedException();
            }
        }

        public List<int> GetAll(int id, int type)
        {
            return RightContext().GetAll(id, type);
        }
    }
}