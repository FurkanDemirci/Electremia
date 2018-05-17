using System.Collections.Generic;
using Electremia.Model.Models;

namespace Electremia.Dal.Interfaces
{
    public interface IPictureRepository : IRepository<Picture>
    {
        List<Picture> GetAll(int id, int type);
    }
}