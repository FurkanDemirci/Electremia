using System.Collections.Generic;
using Electremia.Model.Models;

namespace Electremia.Dal.Interfaces
{
    public interface ISchoolRepository : IRepository<School>
    {
        IEnumerable<School> GetAll(int id);
    }
}