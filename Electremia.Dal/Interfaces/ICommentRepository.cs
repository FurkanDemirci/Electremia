using System.Collections.Generic;
using Electremia.Model.Models;

namespace Electremia.Dal.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        List<Comment> GetAll(int id, int type);
    }
}