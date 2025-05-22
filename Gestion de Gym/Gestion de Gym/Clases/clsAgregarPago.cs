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
    public class clsAgregarPago
    {
        public int iPId { get; set; }
        public int iPMemberId { get; set; }
        public int iPPlanId { get; set; }
        public bool sPStatus { get; set; }
        public DateTime sPEndData { get; set; }
        public decimal sPAmount { get; set; }
        public string sKeyword { get; set; }

        // Propiedad estática para transferencia de datos
        public static clsAgregarPago DatosPay { get; set; }

        public string NameMember;


        public bool Guardar()
        {
            bool bValidar = false;
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Paytbl";
            cmd.Parameters.AddWithValue("@OP", 1);
            cmd.Parameters.AddWithValue("@PPlanId", iPPlanId);
            cmd.Parameters.AddWithValue("@PMembermId", iPMemberId);
            //cmd.Parameters.AddWithValue("@PStatus", );
            cmd.Parameters.AddWithValue("@PEndData", sPEndData);
            cmd.Parameters.AddWithValue("@PAmount", sPAmount);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                bValidar = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el pago: {ex.Message}");
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
            cmd.CommandText = "SP_Paytbl";
            cmd.Parameters.AddWithValue("@OP", 2);
            cmd.Parameters.AddWithValue("@PId", iPId);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                bValidar = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el pago: {ex.Message}");
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

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_PaymentTbl";
            cmd.Parameters.AddWithValue("@OP", 3);

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar todos los pagos: {ex.Message}");
            }
            finally
            {
                con.Close();
            }

            return dt;
        }

        public DataTable ConsultarTodos()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Paytbl";
            cmd.Parameters.AddWithValue("@OP", 7);

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar pagos no realizados: {ex.Message}");
            }
            finally
            {
                con.Close();
            }

            return dt;
        }

        public DataTable ConsultarTodosActivos()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Paytbl";
            cmd.Parameters.AddWithValue("@OP", 6);

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar pagos no realizados: {ex.Message}");
            }
            finally
            {
                con.Close();
            }

            return dt;
        }


        public DataTable ConsultarTodosInactivos()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Paytbl";
            cmd.Parameters.AddWithValue("@OP", 4);

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar pagos no realizados: {ex.Message}");
            }
            finally
            {
                con.Close();
            }

            return dt;
        }


        public DataTable BuscarPorPalabraClave()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Paytbl";
            cmd.Parameters.AddWithValue("@OP", 5);
            cmd.Parameters.AddWithValue("@Keyword", sKeyword ?? string.Empty);

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar pagos por palabra clave: {ex.Message}");
            }
            finally
            {
                con.Close();
            }

            return dt;
        }


        public void ActualizarPagosVencidos()
        {
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand(@"
                                            UPDATE Paytbl
                                            SET PStatus = 0
                                            WHERE PEndData < GETDATE() AND PStatus = 1;
                                        ", con);

            try
            {
                con.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar pagos vencidos: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


    }
}
