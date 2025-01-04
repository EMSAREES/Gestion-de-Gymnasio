using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

    }
}
