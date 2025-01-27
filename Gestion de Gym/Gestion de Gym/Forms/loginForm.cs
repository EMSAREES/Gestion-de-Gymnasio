using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Gestion_de_Gym.Clases;

namespace Gestion_de_Gym.Forms
{
    public partial class loginForm : Form
    {
        
        public loginForm()
        {
            InitializeComponent();
        }
        public static class UsuarioLogueado
        {
            public static string NombreUsuario { get; set; }
            public static string RangoUsuario { get; set; }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            entrar();
        }

        private void entrar()
        {

            clsLogin log = new clsLogin();

            log.sUsName = txtUsuario.Text.ToString();
            log.sUsPassword = clsEncrypt.GetSHA256(txtContraseña.Text);

            if (log.consultar() == true)
            {
                if (log.resultadoInicioSesion)
                {
                    // Autenticación exitosa
                    UsuarioLogueado.NombreUsuario = txtUsuario.Text;

                    // Obtener el rango del usuario desde la base de datos
                    string rangoUsuario = ObtenerRangoUsuario(txtUsuario.Text);
                    if (!string.IsNullOrEmpty(rangoUsuario))
                    {
                        UsuarioLogueado.RangoUsuario = rangoUsuario; // Asignar el rango
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener el rango del usuario.");
                        return;
                    }

                    mainForm mainForm = new mainForm();
                    this.Hide();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("El usuario o la contraseña son incorrectos, intentelo de nuevo");
                }
            }
            else
            {
                MessageBox.Show("no se pudo logial correctamente");
            }
        }


        // Método para obtener el rango del usuario desde la base de datos
        private string ObtenerRangoUsuario(string usuario)
        {
            string rango = string.Empty;
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("SELECT UsRange FROM UserTbl WHERE UsName = @UsName", con);
            cmd.Parameters.AddWithValue("@UsName", usuario);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    rango = reader["UsRange"].ToString(); // Obtener el rango
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

            return rango;
        }

    }


}
