using System;
using Electremia.Dal.Interfaces;
using Electremia.Dal.Memory;
using Electremia.Dal.Sql;
using Electremia.Model.Models;

namespace Electremia.Dal.Repositories
{
    public class AccountRepository : Repository<User>, IAccountRepository
    {
        public AccountRepository(IRepository<User> context) : base(context)
        {
        }

        public User GetByUsername(string username)
        {
            return RightContext().GetByUsername(username);
        }

        public User GetByLogin(string username, string password)
        {
            return RightContext().GetByLogin(username, password);
        }

        private IAccountRepository RightContext()
        {
            switch (Context)
            {
                case AccountSqlContext context:
                    return context;
                case AccountMemoryContext context:
                    return context;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}