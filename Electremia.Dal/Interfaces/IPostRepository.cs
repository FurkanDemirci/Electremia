using Electremia.Model.Models;

namespace Electremia.Dal.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        new int Add(Post entity);
    }
}