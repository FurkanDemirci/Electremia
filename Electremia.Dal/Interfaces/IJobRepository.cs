using System.Collections.Generic;
using Electremia.Model.Models;

namespace Electremia.Dal.Interfaces
{
    public interface IJobRepository : IRepository<Job>
    {
        IEnumerable<Job> GetAll(int id);
    }
}