using System.Collections.Generic;
using Electremia.Dal.Repositories;
using Electremia.Dal.Sql;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class SchoolServices
    {
        private readonly SchoolRepository _repo;

        public SchoolServices()
        {
            _repo = new SchoolRepository(new SchoolSqlContext());
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