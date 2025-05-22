using System;
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
    public partial class addmemberForm : Form
    {
        clsAgregarMiembro clsAgregar = new clsAgregarMiembro();

        public string idtemporal;
        public bool editarMember = false;

        public addmemberForm()
        {
            InitializeComponent();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            this.Hide();
            loginForm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            mainForm mainForm = new mainForm();
            this.Hide();
            mainForm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((txtName.Text == "") || (txtPhone.Text == "") || (txtYear.Text == "") || (cbGender.Text == ""))
            {
                MessageBox.Show("Faltan datos que rellenar");
            }
            else
            {
                agregar();
            }
        }

        private void btnDeleter_Click(object sender, EventArgs e)
        {

            if ((txtName.Text == "") || (txtPhone.Text == "") || (txtYear.Text == "") || (cbGender.Text == ""))
            {
                MessageBox.Show("Faltan datos que rellenar");
            }
            else
            {
                eliminar();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            viewMemberForm viewMemberForm = new viewMemberForm();
            this.Hide();
            viewMemberForm.Show();
        }

        private void agregar()
        {
            

            if (editarMember)
            {
                clsAgregar.iId = int.Parse(idtemporal);
            }

            clsAgregar.sName = txtName.Text.ToString();
            clsAgregar.sPhone = txtPhone.Text.ToString();
            clsAgregar.sGen = cbGender.Text.ToString();
            clsAgregar.sAge = int.Parse(txtYear.Text.ToString());
            clsAgregar.sIdUser = UsuarioLogueado.IdUsuario;

            if (editarMember == false)
            {
                if (clsAgregar.miembroExiste())
                {
                    MessageBox.Show("El miembro ya existe.");
                    return; // Detener la ejecución si el usuario ya existe
                }
            }

            if(clsAgregar.Guardar() == true)
            {
                MessageBox.Show("Sus datos se a Guardado correctamente");
                limpiar();
            }

        }

        private void eliminar ()
        {
            clsAgregar.iId = int.Parse(idtemporal);

            if (clsAgregar.Eliminar() == true)
            {
                MessageBox.Show("Sus datos se eliminaron correctamente");
                limpiar();
            }
            else
            {
                MessageBox.Show("Sus datos no se a eliminado correctamente");
            }
        }

        private void limpiar()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtYear.Clear();
            cbGender.SelectedIndex = -1;
        }

        private void addmemberForm_Load(object sender, EventArgs e)
        {
            if (editarMember && clsAgregarMiembro.DatosEditar != null)
            {
                idtemporal = clsAgregarMiembro.DatosEditar.iId.ToString();
                txtName.Text = clsAgregarMiembro.DatosEditar.sName;
                txtPhone.Text = clsAgregarMiembro.DatosEditar.sPhone;
                txtYear.Text = clsAgregarMiembro.DatosEditar.sAge.ToString();
                cbGender.Text = clsAgregarMiembro.DatosEditar.sGen;
            }
        }
    }
}
