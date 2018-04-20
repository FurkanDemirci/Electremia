using System;
using System.Collections.Generic;
using Electremia.Dal.Interfaces;
using Electremia.Dal.Memory;
using Electremia.Dal.Sql;
using Electremia.Model.Models;

namespace Electremia.Dal.Repositories
{
    public class SchoolRepository : Repository<School>, ISchoolRepository
    {
        public SchoolRepository(IRepository<School> context) : base(context)
        {
        }

        public IEnumerable<School> GetAll(int id)
        {
            return RightContext().GetAll(id);
        }

        private ISchoolRepository RightContext()
        {
            switch (Context)
            {
                case SchoolSqlContext context:
                    return context;
                case SchoolMemoryContext context:
                    return context;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}