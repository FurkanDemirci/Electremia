﻿using System;
using System.Collections.Generic;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Memory
{
    public class SchoolMemoryContext : ISchoolRepository
    {
        public School GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(School entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(School entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(School entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<School> GetAll(int id)
        {
            throw new NotImplementedException();
        }
    }
}