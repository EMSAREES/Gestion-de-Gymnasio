using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Web.ModelBinding;

namespace Gestion_de_Gym.Clases
{
    internal class clsAgregarUsasrio
    {
        public int iUsId { get; set; }
        public string sUsName { get; set; }
        public string sUsPassword { get; set; }
        public string sUsRange { get; set; }

        public bool Guardar()
        {
            bool bValidar = false;
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("", con);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_UserTbl";
            cmd.Parameters.AddWithValue("@OP", 1);
            cmd.Parameters.AddWithValue("@UsId", iUsId);
            cmd.Parameters.AddWithValue("@UsName", sUsName);
            cmd.Parameters.AddWithValue("@UsPassword", sUsPassword);
            cmd.Parameters.AddWithValue("@UsRange", sUsRange);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                bValidar = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}");
                bValidar = false;
            }
            finally
            {
                con.Close();
            }
            return bValidar;
        }


        public bool Eliminar()
        {
            bool bValidar = false;
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("", con);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_UserTbl";
            cmd.Parameters.AddWithValue("@OP", 2);
            cmd.Parameters.AddWithValue("@UsId", iUsId);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                bValidar = true;
            }
            catch
            {
                bValidar = false;
            }
            finally
            {
                con.Close();
            }
            return bValidar;
        }


        public DataSet obtener()
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("", con);

            try
            {
                con.Open();
                string consulta = "SELECT * FROM UserTbl";
                SqlDataAdapter da = new SqlDataAdapter(consulta, con);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                // Manejar la excepción de alguna manera (por ejemplo, registrarla o notificar al usuario)
                Console.WriteLine($"Error al obtener los datos: {ex.Message}");
            }
            finally
            {
                // Cerrar la conexión incluso si ocurre una excepción
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return ds;
        }

    }
}
