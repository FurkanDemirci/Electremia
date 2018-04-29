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

        public SchoolServices(SchoolRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<School> GetAll(int id)
        {
            return _repo.GetAll(id);
        }

        // GetSchools(id)
        // Add(model)

        // Edit(model)
        public bool Edit(List<School> schools)
        {
            foreach (var school in schools)
            {
                if (!_repo.Update(school))
                {
                    return false;
                }                
            }
            return true;
        }

        // Delete(model)
    }
}