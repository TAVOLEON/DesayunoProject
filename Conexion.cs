using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesayunoProject
{
    class Conexion
    {
        public static MySqlConnection conexion()
        {
            String cadenaConexion = "server=localhost;user id=root;Password= 1234;database=desayunos";
            try
            {
                MySqlConnection conexionDB = new MySqlConnection(cadenaConexion);
                return conexionDB;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: "+ ex.Message);
                return null;
            }
        }
        
    }
}
