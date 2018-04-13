using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Electremia.Dal.Sql;
using Electremia.Model.Models;
using Electremia.Model.ViewModels;

namespace Electremia.Logic.Services
{
    public class AccountServices
    {
        private AccountSqlRepository repo;

        public AccountServices()
        {
            repo = new AccountSqlRepository
            {
                ConnectionString = 
                    new SqlConnection("Data Source=mssql.fhict.local;Initial Catalog=dbi388198;Persist Security Info=True;User ID=dbi388198;Password=Demirci1")
            };
    }

        public User Login(LoginViewModel model)
        {
            var user = repo.GetByUsername(model.Username);

            if (user == null)
            {
                return null;
            }

            return user.Password != model.Password ? null : user;
        }

        public bool Register(RegisterViewModel model)
        {
            var user = new User
            {
                Username = model.Username,
                Password = model.Password,
                Firstname = model.Firstname,
                Lastname = model.Lastname
            };
            return repo.Add(user);
        }
    }
}
