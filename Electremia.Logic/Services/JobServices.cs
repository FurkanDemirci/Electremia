using System.Collections.Generic;
using Electremia.Dal.Memory;
using Electremia.Dal.Repositories;
using Electremia.Dal.Sql;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class JobServices
    {
        private readonly JobRepository _repo;

        public JobServices(string context)
        {
            switch (context)
            {
                case "MSSQL":
                    _repo = new JobRepository(new JobSqlContext());
                    break;
                default:
                    _repo = new JobRepository(new JobMemoryContext());
                    break;
            }
        }

        // GetAll(id)
        public IEnumerable<Job> GetAll(int id)
        {
            return _repo.GetAll(id);
        }

        // GetJobs(id)
        public bool Add(Job model)
        {
            return _repo.Add(model);
        }

        // Add(model)
        public bool Add(List<Job> jobs)
        {
            foreach (var job in jobs)
            {
                if (!_repo.Add(job))
                {
                    return false;
                }            
            }
            return true;
        }
        
        // Edit
        // Edit(model)
        // Delete(model)
    }
}