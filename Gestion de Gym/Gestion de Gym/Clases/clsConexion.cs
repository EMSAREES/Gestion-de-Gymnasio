using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Gym.Clases
{
    internal class clsConexion
    {
        public static string conectar()
        {
            string con = @"DATA Source=DESKTOP-FB108VB\SQLEXPRESS;INITIAL CATALOG=GymDb;USER=sa;PASSWORD=6870021";

            return con;
        }

        //public static string conectar()
        //{
        //    string conString = @"DATA Source=DESKTOP-FB108VB\SQLEXPRESS;INITIAL CATALOG=GymDb;USER=sa;PASSWORD=6870021";

        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conString))
        //        {
        //            con.Open();
        //            // La conexión se ha abierto correctamente, podemos retornar la cadena de conexión
        //            return conString;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // En caso de error, muestra un mensaje de error en la consola y devuelve una cadena vacía
        //        Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
        //        return string.Empty;
        //    }

        //}
    }
}
