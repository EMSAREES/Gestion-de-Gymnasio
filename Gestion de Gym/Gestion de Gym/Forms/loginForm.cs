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

       
    }
}
