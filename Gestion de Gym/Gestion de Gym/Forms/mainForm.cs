﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion_de_Gym.Clases;
using static Gestion_de_Gym.Forms.loginForm;

namespace Gestion_de_Gym.Forms
{
    public partial class mainForm : Form
    {

        public mainForm()
        {
            InitializeComponent();

            clsAgregarPago pago = new clsAgregarPago();
            pago.ActualizarPagosVencidos();

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            // Mostrar el nombre de usuario logueado en el TextBox
            textBoxUsuario.Text = UsuarioLogueado.NombreUsuario;
            textBoxRango.Text = UsuarioLogueado.RangoUsuario;
            // Obtener la fecha y hora actual
            DateTime fechaYHoraActual = DateTime.Now;

            // Actualizar el texto del Label con la fecha y hora actual
            labelFechaYHora.Text = $"{fechaYHoraActual}";

            if (textBoxRango.Text == "Admin")
            {
                adminBtn.Enabled = true;
                adminBtn.Visible = true;   // El botón será visible

            }
            else
            {
                adminBtn.Visible = false;  // El botón será invisible

            }
        }

        private void agregar_Click(object sender, EventArgs e)
        {
            addmemberForm addmemberForm = new addmemberForm();
            this.Hide();
            addmemberForm.Show();
        }

        private void actualizar_Click(object sender, EventArgs e)
        {
            searchSuscritosForm updateDeleteForm = new searchSuscritosForm();
            this.Hide();
            updateDeleteForm.Show();
        }

        private void Lista_Click(object sender, EventArgs e)
        {
            viewMemberForm viewMemberForm = new viewMemberForm();
            this.Hide();
            viewMemberForm.Show();
        }

        private void Pago_Click(object sender, EventArgs e)
        {
            paymentsForms paymentsForms = new paymentsForms();
            this.Hide();
            paymentsForms.Show();
        }

        private void AgregarUsuario_Click(object sender, EventArgs e)
        {
            adminForm adminForm = new adminForm();
            this.Hide();
            adminForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            this.Hide();
            loginForm.Show();
        }
    }
}
