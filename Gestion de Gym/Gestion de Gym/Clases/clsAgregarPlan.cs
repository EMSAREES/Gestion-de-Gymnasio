using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace Gestion_de_Gym.Clases
{
    internal class clsAgregarPlan
    {
        public int iPlId { get; set; }
        public string sUsName { get; set; }
        public float sPLPrice { get; set; }
        public int sPLDaysCovered { get; set; }

        public bool Guardar()
        {
            bool bValidar = false;
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("", con);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_PlansTbl";
            cmd.Parameters.AddWithValue("@OP", 1);
            cmd.Parameters.AddWithValue("@PLId", iPlId);
            cmd.Parameters.AddWithValue("@PLName", sUsName);
            cmd.Parameters.AddWithValue("@PLPrice", sPLPrice);
            cmd.Parameters.AddWithValue("@PLDaysCovered", sPLDaysCovered);

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
            cmd.CommandText = "SP_PlansTbl";
            cmd.Parameters.AddWithValue("@OP", 2);
            cmd.Parameters.AddWithValue("@PLId", iPlId);

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

        public DataTable Consultar()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("", con);

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_PlansTbl";

                cmd.Parameters.AddWithValue("@OP", 3);
                cmd.Parameters.AddWithValue("@PLId", 0);
                cmd.Parameters.AddWithValue("@PLName", "");
                cmd.Parameters.AddWithValue("@PLPrice", 0);
                cmd.Parameters.AddWithValue("@PLDaysCovered", 0);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                cmd.Dispose();
                con.Dispose();
            }

            return dt;
        }



        public bool planExistente()
        {
            bool existe = false;

            using (SqlConnection con = new SqlConnection(clsConexion.conectar()))
            {
                SqlCommand cmd = new SqlCommand("SP_PlansTbl", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OP", 5);
                cmd.Parameters.AddWithValue("@PLName", sUsName);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int resultado = Convert.ToInt32(reader["Existe"]);
                        existe = resultado > 0;
                    }
                }
                catch
                {
                    existe = true; // Por seguridad, tratamos errores como si ya existiera
                }
            }

            return existe;
        }



    }

}
