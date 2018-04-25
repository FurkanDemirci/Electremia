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

        #region AccountService
        private IAccountRepository NewAccountRepository()
        {
            switch (_context)
            {
                case "MSSQL":
                    return new AccountSqlContext();
                case "Memory":
                    return new AccountMemoryContext();
                default:
                    throw new NotImplementedException();
            }
        }
        public AccountServices AccountService() => new AccountServices(new AccountRepository(NewAccountRepository()));
        #endregion

        #region JobService
        private IJobRepository NewJobRepository()
        {
            switch (_context)
            {
                case "MSSQL":
                    return new JobSqlContext();
                case "Memory":
                    return new JobMemoryContext();
                default:
                    throw new NotImplementedException();
            }
        }
        public JobServices JobService() => new JobServices(new JobRepository(NewJobRepository()));
        #endregion

        #region SchoolService
        private ISchoolRepository NewSchoolRepository()
        {
            switch (_context)
            {
                case "MSSQL":
                    return new SchoolSqlContext();
                case "Memory":
                    return new SchoolMemoryContext();
                default:
                    throw new NotImplementedException();
            }
        }
        public SchoolServices SchoolService() => new SchoolServices(new SchoolRepository(NewSchoolRepository()));
        #endregion
    }
}
