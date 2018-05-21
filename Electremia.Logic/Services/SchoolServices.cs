﻿using System.Collections.Generic;
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

        /// <summary>
        /// Get all schools.
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns>IEnumerable of schools</returns>
        public IEnumerable<School> GetAll(int id)
        {
            // Check for empty values
            if (id <= 0)
                throw new ExceptionHandler("NotImplemented", "Not all parameters are filled");

            return _repo.GetAll(id);
        }

        /// <summary>
        /// Edit the schools.
        /// </summary>
        /// <param name="schools">List of schools</param>
        /// <returns>Boolean</returns>
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
    }
}