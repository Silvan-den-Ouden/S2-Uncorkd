using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Uncorkd_DAL.DALs
{
    internal class Connector
    {
        private static readonly string connectionString = "Server=127.0.0.1,3306;Database=uncorkd;Uid=root;";

        public static MySqlConnection MakeConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
