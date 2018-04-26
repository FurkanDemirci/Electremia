using System;
using System.Collections.Generic;
using System.Text;
using Electremia.Dal.Interfaces;
using Electremia.Dal.Memory;
using Electremia.Dal.Repositories;
using Electremia.Dal.Sql;
using Electremia.Logic.Services;
using Electremia.Model.Models;
using Microsoft.Extensions.Configuration;

namespace Electremia.Logic
{
    public class Factory
    {
        //private readonly string _connectionString;
        private readonly string _context;

        public Factory(IConfiguration config)
        {
            _context = config.GetSection("Database")["Type"];
        }

        public AccountServices AccountService()
        {
            switch (_context)
            {
                case "MSSQL":
                    return new AccountServices(new AccountRepository(new AccountSqlContext()));
                default: throw new NotImplementedException();
            }
        }

        public JobServices JobService()
        {
            switch (_context)
            {
                case "MSSQL":
                    return new JobServices(new JobRepository(new JobSqlContext()));
                default: throw new NotImplementedException();
            }
        }

        public SchoolServices SchoolService()
        {
            switch (_context)
            {
                case "MSSQL":
                    return new SchoolServices(new SchoolRepository(new SchoolSqlContext()));
                default: throw new NotImplementedException();
            }
        }
    }
}
