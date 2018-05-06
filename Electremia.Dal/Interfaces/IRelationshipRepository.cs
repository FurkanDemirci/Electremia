using System.Collections.Generic;
using Electremia.Model.Models;

namespace Electremia.Dal.Interfaces
{
    public interface IRelationshipRepository : IRepository<Relationship>
    {
        Dictionary<string, Relationship> GetPending(int id);
        Dictionary<string, Relationship> GetSended(int id);
        Dictionary<string, Relationship> GetFriends(int id);
        bool CheckRelationship(Relationship relationship);
    }
}