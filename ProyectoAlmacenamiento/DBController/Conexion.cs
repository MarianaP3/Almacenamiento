using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAlmacenamiento.DBController
{
    public static class Conexion
    {
        private const string connectionString = "Server = DESKTOP-HEOM77M\\SQLEXPRESS; " +
          "DATABASE = Almacenamiento; integrated security=true";

        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
