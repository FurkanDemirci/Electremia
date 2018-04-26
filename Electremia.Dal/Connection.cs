using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Electremia.Dal
{
    //TODO Dit kan via de config file.
    public abstract class Connection
    {
        // Hard coded connectionstring.
        public readonly SqlConnection MSSQLConnectionString;

        protected Connection()
        {
            MSSQLConnectionString = 
                new SqlConnection("Data Source=mssql.fhict.local;Initial Catalog=dbi388198;Persist Security Info=True;User ID=dbi388198;Password=Demirci1");
        }
    }
}
