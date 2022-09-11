using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using TIKTOK.Core.Domain;

namespace TIKTOK.Infra.Domain
{
    public class DBContext : IDBContext
    {
        private DbConnection _dbconction;
        private IConfiguration _configration;

        /*when execute project we will inialize value by constructor */
        public DBContext(IConfiguration configration)
        {
            _configration = configration;
        }

        public DbConnection dbConnection
        {

            /*
            check connection if null or nut if (connection==null)
            check connection if close () i want open connection string 
            new oracleconnection(configuration)this is get connection string 
            in appsettings.json
            */
            get
            {
                if (_dbconction == null)
                {
                    _dbconction = new OracleConnection(_configration["ConnectionStrings:DBConnectionString"]);
                    

                    _dbconction.Open();
                }
                else if (_dbconction.State != System.Data.ConnectionState.Open)
                {
                    _dbconction.Open();
                }
                return _dbconction;
            }
        }
    }
}
