using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Gestion_de_Gym.Clases
{
    public class clsAgregarMiembro
    {
        public int iId { get; set; }
        public string sName { get; set; }
        public string sPhone { get; set; }
        public string sGen { get; set; }
        public int sAge { get; set; }
        public int sIdUser { get; set; }

        // Propiedad estática para transferencia de datos
        public static clsAgregarMiembro DatosEditar { get; set; }
        public bool Guardar()
        {
            bool bValidar = false;
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MemberTbl";
            cmd.Parameters.AddWithValue("@OP", 1);
            cmd.Parameters.AddWithValue("@MId", iId);
            cmd.Parameters.AddWithValue("@MName", sName);
            cmd.Parameters.AddWithValue("@MPhone", sPhone );
            cmd.Parameters.AddWithValue("@MGen", sGen);
            cmd.Parameters.AddWithValue("@MAge", sAge);
            cmd.Parameters.AddWithValue("@IdUser", sIdUser);

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

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MemberTbl";
            cmd.Parameters.AddWithValue("@OP", 2);
            cmd.Parameters.AddWithValue("@MId", iId);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                bValidar = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}");
                bValidar = false;
            }
            finally
            {
                con.Close();
            }
            return bValidar;
        }

        public DataTable ConsultarGeneral()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MemberTbl";
            cmd.Parameters.AddWithValue("@OP", 4);
            //cmd.Parameters.AddWithValue("@MId", iId);
            //cmd.Parameters.AddWithValue("@MName", sName);
            //cmd.Parameters.AddWithValue("@MPhone", sPhone );
            //cmd.Parameters.AddWithValue("@MGen", sGen);
            //cmd.Parameters.AddWithValue("@MAge", sAge);

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar: {ex.Message}");
            }
            finally
            {
                con.Close();
            }

            return dt;
        }

        public bool miembroExiste()
        {
            bool existe = false;
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MemberTbl";
            cmd.Parameters.AddWithValue("@OP", 3);
            cmd.Parameters.AddWithValue("@MName", sName);
            cmd.Parameters.AddWithValue("@MPhone", sPhone);

            try
            {
                con.Open();

                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int count))
                {
                    existe = (count > 0);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar existencia: {ex.Message}");
            }
            finally
            {
                con.Close();
            }

            return existe;
        }

        public DataTable BuscarPorNombre()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MemberTbl";
            cmd.Parameters.AddWithValue("@OP", 5);
            cmd.Parameters.AddWithValue("@MName", sName);

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar por nombre: {ex.Message}");
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
    }
}
