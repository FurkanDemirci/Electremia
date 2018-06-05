using Electremia.Dal.Interfaces;
using Electremia.Dal.Memory;
using Electremia.Dal.Sql;
using Electremia.Model.Models;
using System;
using System.Collections.Generic;

namespace Electremia.Dal.Repositories
{
    public class RelationshipRepository : Repository<Relationship>, IRelationshipRepository
    {
        public RelationshipRepository(IRepository<Relationship> context) : base(context)
        {
        }

        private IRelationshipRepository RightContext()
        {
            switch (Context)
            {
                case RelationshipSqlContext context:
                    return context;
                case RelationshipMemoryContext context:
                    return context;
                default:
                    throw new NotImplementedException();
            }
        }

        public Dictionary<string, Relationship> GetPending(int id)
        {
            return RightContext().GetPending(id);
        }

        public Dictionary<string, Relationship> GetSended(int id)
        {
            return RightContext().GetSended(id);
        }

        public Dictionary<string, Relationship> GetFriends(int id)
        {
            return RightContext().GetFriends(id);
        }

        public bool CheckRelationship(Relationship relationship)
        {
            return RightContext().CheckRelationship(relationship);
        }
    }
}