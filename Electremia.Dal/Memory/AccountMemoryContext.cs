using System;
using System.Collections.Generic;
using System.Text;
using Electremia.Dal.Interfaces;
using Electremia.Model.Models;

namespace Electremia.Dal.Memory
{
    public class AccountMemoryContext : IAccountRepository
    {
        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public User GetByLogin(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
