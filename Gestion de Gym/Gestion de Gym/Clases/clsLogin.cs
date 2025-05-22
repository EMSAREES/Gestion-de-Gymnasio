using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Gestion_de_Gym.Forms.loginForm;

namespace Gestion_de_Gym.Clases
{
    internal class clsLogin
    {
        public string sUsName { get; set; }
        public string sUsPassword { get; set; }

        public bool resultadoInicioSesion; 


        public bool consultar()
        {
            bool bValidar = false;
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("", con);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "Sp_LoginUsuario";
            cmd.Parameters.AddWithValue("@UsName", sUsName);
            cmd.Parameters.AddWithValue("@UsPassword", sUsPassword);
            cmd.Parameters.Add("@result", SqlDbType.Bit).Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                bValidar = true;

               resultadoInicioSesion = Convert.ToBoolean(cmd.Parameters["@result"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error alLogiar los datos: {ex.Message}");
                bValidar = false;
            }
            finally
            {
                con.Close();
            }
            return bValidar;
        }

        //public class ResultadoUsuario
        //{
        //    public int idUsuario { get; set; }
        //    public string rango { get; set; }
        //}



        //Método para obtener el rango del usuario desde la base de datos
        public (string, int) ObtenerDatoUsuario(string usuario)
        {
            string rango = string.Empty;
            int idUsuario = 0;
            //ResultadoUsuario resultado = null;
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("SELECT UsRange, UsId FROM UserTbl WHERE UsName = @UsName", con);
            cmd.Parameters.AddWithValue("@UsName", usuario);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    rango = reader["UsRange"].ToString(); // Obtener el rango
                    idUsuario = Convert.ToInt32(reader["UsId"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el rango del usuario: {ex.Message}");
            }
            finally
            {
                con.Close();
            }

            return (rango, idUsuario);

        }

    }

}

