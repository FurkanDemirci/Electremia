using Electremia.Dal.Interfaces;
using Electremia.Model.Models;
using System;
using System.Collections.Generic;

namespace Electremia.Dal.Memory
{
    public class JobMemoryContext : IJobRepository
    {
        public Job GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Job entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Job entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Job entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAll(int id)
        {
            throw new NotImplementedException();
        }
    }
}