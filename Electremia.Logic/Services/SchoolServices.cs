using System.Collections.Generic;
using Electremia.Dal.Memory;
using Electremia.Dal.Repositories;
using Electremia.Dal.Sql;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class SchoolServices
    {
        private readonly SchoolRepository _repo;

        public SchoolServices(string context)
        {
            switch (context)
            {
                case "MSSQL":
                    _repo = new SchoolRepository(new SchoolSqlContext());
                    break;
                default:
                    _repo = new SchoolRepository(new SchoolMemoryContext());
                    break;
            }
        }

        public IEnumerable<School> GetAll(int id)
        {
            return _repo.GetAll(id);
        }

        // GetSchools(id)
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}