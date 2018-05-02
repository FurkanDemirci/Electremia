using System.Collections.Generic;
using Electremia.Model.Models;

namespace Electremia.Dal.Interfaces
{
    public interface IRelationshipRepository : IRepository<Relationship>
    {
        //GetAll pending
        Dictionary<string, Relationship> GetPending(int id);
        //GetAll blocked
        //GetAll declined
    }
}