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

namespace Gestion_de_Gym.Forms
{
    public partial class viewMemberForm : Form
    {
        clsAgregarMiembro clsAgregar = new clsAgregarMiembro();
        addmemberForm form = new addmemberForm();

        private int index = 0;
        private int selectedRowIndex = -1;
        public viewMemberForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            this.Hide();
            loginForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm mainForm = new mainForm();
            this.Hide();
            mainForm.Show();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    btnEditar.Enabled = true;  // Habilita el botón cuando se selecciona una fila
                    index = e.RowIndex;
                }
                else
                {
                    btnEditar.Enabled = false; // Deshabilita si no hay selección válida
                }

                if (e.RowIndex < 0)
                    return;

                // Restaurar color anterior si hay alguno
                if(selectedRowIndex >= 0 && selectedRowIndex < guna2DataGridView1.Rows.Count)
                {
                    guna2DataGridView1.Rows[selectedRowIndex].DefaultCellStyle.BackColor = Color.White;
                    guna2DataGridView1.Rows[selectedRowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }

                // Guardar nueva fila seleccionada
                selectedRowIndex = e.RowIndex;

                // Cambiar color de toda la fila
                guna2DataGridView1.Rows[selectedRowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 128, 128);
                guna2DataGridView1.Rows[selectedRowIndex].DefaultCellStyle.ForeColor = Color.White;

                index = selectedRowIndex;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error al seleccionar la fila: {ex.Message}");
            }

        }

        private void viewMemberForm_Load(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;

            DataTable dt = clsAgregar.ConsultarGeneral();

            if (!dt.Columns.Contains("MId")) dt.Columns.Add("MId");
            if (!dt.Columns.Contains("MName")) dt.Columns.Add("MName");
            if (!dt.Columns.Contains("MPhone")) dt.Columns.Add("MPhone");
            if (!dt.Columns.Contains("MGen")) dt.Columns.Add("MGen");
            if (!dt.Columns.Contains("MAge")) dt.Columns.Add("MAge");

            DataTable newDt = dt.Clone();

            foreach (DataRow r in dt.Rows)
            {
                DataRow dr = newDt.NewRow();
                dr["MId"] = r["MId"].ToString();
                dr["MName"] = r["MName"].ToString();
                dr["MPhone"] = r["MPhone"].ToString();
                dr["MGen"] = r["MGen"].ToString();
                dr["MAge"] = r["MAge"].ToString();
                newDt.Rows.Add(dr);
            }

            guna2DataGridView1.DataSource = newDt;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {

                // Crear y llenar el objeto temporal
                clsAgregarMiembro.DatosEditar = new clsAgregarMiembro();
                clsAgregarMiembro.DatosEditar.iId = int.Parse(guna2DataGridView1.Rows[index].Cells["MId"].Value?.ToString());
                clsAgregarMiembro.DatosEditar.sName = guna2DataGridView1.Rows[index].Cells["MName"].Value?.ToString();
                clsAgregarMiembro.DatosEditar.sPhone = guna2DataGridView1.Rows[index].Cells["MPhone"].Value?.ToString();
                clsAgregarMiembro.DatosEditar.sGen = guna2DataGridView1.Rows[index].Cells["MGen"].Value?.ToString();
                clsAgregarMiembro.DatosEditar.sAge = int.Parse(guna2DataGridView1.Rows[index].Cells["MAge"].Value?.ToString());

                // Abrir formulario de edición
                form.editarMember = true;
                form.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void buscar()
        {
            DataTable dt;

            if (string.IsNullOrWhiteSpace(txtPClave.Text))
            {
                // Si el TextBox está vacío, mostramos todos los miembros
                dt = clsAgregar.ConsultarGeneral();
            }
            else
            {
                // Si hay texto, hacemos búsqueda por nombre
                clsAgregar.sName = txtPClave.Text;
                dt = clsAgregar.BuscarPorNombre();
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                guna2DataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No se encontraron resultados.");
                guna2DataGridView1.DataSource = null;
            }
        }

        private void btnSuscribir_Click(object sender, EventArgs e)
        {
            paymentsForms payments = new paymentsForms();

            try
            {

                // Crear y llenar el objeto temporal
                clsAgregarPago.DatosPay = new clsAgregarPago();
                clsAgregarPago.DatosPay.iPId = int.Parse(guna2DataGridView1.Rows[index].Cells["MId"].Value?.ToString());
                clsAgregarPago.DatosPay.NameMember = guna2DataGridView1.Rows[index].Cells["MName"].Value?.ToString();

                // Abrir formulario de edición
                //payments.editarPay = true;
                payments.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar: {ex.Message}");
            }

        }
    }
    
}
