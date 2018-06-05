namespace Electremia.Dal.Interfaces
{
    /// <summary>
    /// CRUD Operations
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    public interface IRepository<T>
    {
        T GetById(int id); // READ
        bool Add(T entity); // CREATE
        bool Update(T entity); // UPDATE
        bool Delete(T entity); // DELLETE
    }
}
