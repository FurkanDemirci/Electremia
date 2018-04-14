using Electremia.Model.Models;

namespace Electremia.Dal.Interfaces
{
    public interface IAccountRepository : IRepository<User>
    {
        User GetByUsername(string username);
    }
}