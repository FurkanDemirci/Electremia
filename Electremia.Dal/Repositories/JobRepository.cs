using Electremia.Dal.Interfaces;
using Electremia.Dal.Memory;
using Electremia.Dal.Sql;
using Electremia.Model.Models;
using System;
using System.Collections.Generic;

namespace Electremia.Dal.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(IRepository<Job> context) : base(context)
        {
        }

        public IEnumerable<Job> GetAll(int id)
        {
            return RightContext().GetAll(id);
        }

        public bool DeleteAll(int id)
        {
            return RightContext().DeleteAll(id);
        }

        private IJobRepository RightContext()
        {
            switch (Context)
            {
                case JobSqlContext context:
                    return context;
                case JobMemoryContext context:
                    return context;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}