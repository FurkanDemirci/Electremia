using System.Collections.Generic;
using Electremia.Model.Models;

namespace Electremia.Dal.Interfaces
{
    public interface ILikeRepository : IRepository<Like>
    {
        List<int> GetAll(int id, int type);
    }
}