using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Electremia.Model.Models;

namespace Electremia.Dal.Sql
{
    public class AccountSqlRepository : IRepository<User>
    {
        public User GetByUsername(string username)
        {
            // SQL eigenlijk
            // hardcode
            if (username == "FurkanDemirci")
            {
                var user = new User
                {
                    UserId = 0,
                    Firstname = "Furkan",
                    Lastname = "Demirci",
                    Username = "FurkanDemirci",
                    Password = "Admin123",
                    ProfilePicture = "",
                    CoverPicture = "",
                    Certificate = "MBO",
                    Active = true,
                    Jobs = null,
                    Schools = null,
                    Relationships = null,
                };
                return user;
            }
            return null;
        }

        public object GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(User entity)
        {
            // SQL CODE voor inserten
            // Stuurt Bool terug of het is gelukt.
            return true;
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
