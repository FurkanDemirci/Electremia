using System;
using System.Collections.Generic;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Memory
{
    public class RelationshipMemoryContext : IRelationshipRepository
    {
        public Relationship GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Relationship entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Relationship entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Relationship entity)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, Relationship> GetPending(int id)
        {
            throw new NotImplementedException();
        }
    }
}