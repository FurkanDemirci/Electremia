using System.Collections.Generic;
using System.Text;
using Electremia.Dal.Interfaces;

namespace Electremia.Dal.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        protected readonly IRepository<TEntity> Context;

        public Repository(IRepository<TEntity> context)
        {
            Context = context;
        }

        public TEntity GetById(int id)
        {
            return Context.GetById(id);
        }

        public bool Add(TEntity entity)
        {
            return Context.Add(entity);
        }

        public bool Update(TEntity entity)
        {
            return Context.Update(entity);
        }

        public bool Delete(TEntity entity)
        {
            return Context.Delete(entity);
        }
    }
}
