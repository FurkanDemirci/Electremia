using System;
using Electremia.Dal.Interfaces;
using Electremia.Dal.Memory;
using Electremia.Dal.Sql;
using Electremia.Model.Models;

namespace Electremia.Dal.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(IRepository<Post> context) : base(context)
        {
        }

        private IPostRepository RightContext()
        {
            switch (Context)
            {
                case PostSqlContext context:
                    return context;
                case PostMemoryContext context:
                    return context;
                default:
                    throw new NotImplementedException();
            }
        }

        public new int Add(Post entity)
        {
            return RightContext().Add(entity);
        }
    }
}