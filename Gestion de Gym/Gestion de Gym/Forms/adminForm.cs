using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_Gym.Forms
{
    public partial class adminForm : Form
    {
        public adminForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            mainForm mainForm = new mainForm();
            this.Hide();
            mainForm.Show();
        }

        private void AgregarUsuario_Click(object sender, EventArgs e)
        {
            mainForm mainform = new mainForm();
            mainform.Close();

            adduserForm adduserForm = new adduserForm();
            this.Hide();
            adduserForm.Show();
        }

        private void agregarPlanBtn_Click(object sender, EventArgs e)
        {
            mainForm mainform = new mainForm();
            mainform.Close();

           addPlanForm addPlan = new addPlanForm();
            this.Hide();
            addPlan.Show();
        }
    }
}
