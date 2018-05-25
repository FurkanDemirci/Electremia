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

        public JobServices(JobRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get all jobs from user.
        /// </summary>
        /// <param name="id">UserId int</param>
        /// <returns>IEnumarable of Jobs.</returns>
        public IEnumerable<Job> GetAll(int id)
        {
            // Check for empty values
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Not all parameters are filled");

            return _repo.GetAll(id);
        }

        /// <summary>
        /// Add list of jobs.
        /// </summary>
        /// <param name="jobs">List of jobs</param>
        /// <returns>Boolean</returns>
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

        /// <summary>
        /// Delete job.
        /// </summary>
        /// <param name="model">Job model</param>
        /// <returns>Boolean</returns>
        public bool Delete(Job model)
        {
            return _repo.Delete(model);
        }

        /// <summary>
        /// Delete all jobs from user.
        /// </summary>
        /// <param name="id">UserId int</param>
        /// <returns>Boolean</returns>
        public bool DeleteAll(int id)
        {
            // Check for empty values
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Not all parameters are filled");

            return _repo.DeleteAll(id);
        }

        /// <summary>
        /// Edit the jobs.
        /// </summary>
        /// <param name="jobs">List of Jobs</param>
        /// <returns>Boolean</returns>
        public bool Edit(List<Job> jobs)
        {
            foreach (var job in jobs)
            {
                if (!_repo.Update(job))
                {
                    return false;
                }
            }
            return true;
        }
    }
}