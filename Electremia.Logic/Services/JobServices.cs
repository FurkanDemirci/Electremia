﻿using System.Collections.Generic;
using Electremia.Dal.Repositories;
using Electremia.Dal.Sql;
using Electremia.Model.Models;

namespace Electremia.Logic.Services
{
    public class JobServices
    {
        private readonly JobRepository _repo;

        public JobServices()
        {
            _repo = new JobRepository(new JobSqlContext());
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
        // Add(model)
        // Edit(model)
        // Delete(model)
    }
}