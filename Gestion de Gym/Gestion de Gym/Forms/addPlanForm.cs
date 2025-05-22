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
    public partial class addPlanForm : Form
    {
        private int index = 0;
        private string idtemporal;
        private bool editarPlan = false;
        private int selectedRowIndex = -1;

        public addPlanForm()
        {
            InitializeComponent();
        }

       

        private void label3_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            this.Hide();
            loginForm.Show();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            mainForm mainForm = new mainForm();
            this.Hide();
            mainForm.Show();
        }

        private void btnAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la entrada si no es un número
            }

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
                if (selectedRowIndex >= 0 && selectedRowIndex < guna2DataGridView1.Rows.Count)
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

        private void addPlan_Load(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;

            clsAgregarPlan clsAgregar = new clsAgregarPlan();
            DataTable dt = clsAgregar.Consultar();

            // Asegurar que las columnas existen antes de recorrer las filas
            if (!dt.Columns.Contains("PLId")) dt.Columns.Add("PLId");
            if (!dt.Columns.Contains("PLName")) dt.Columns.Add("PLName");
            if (!dt.Columns.Contains("PLPrice")) dt.Columns.Add("PLPrice");
            if (!dt.Columns.Contains("PLDaysCovered")) dt.Columns.Add("PLDaysCovered");

            DataTable newDt = dt.Clone(); // Clonar la estructura para evitar conflictos

            foreach (DataRow r in dt.Rows)
            {
                DataRow dr = newDt.NewRow();
                dr["PLId"] = r["PLId"].ToString();
                dr["PLName"] = r["PLName"].ToString();
                dr["PLPrice"] = r["PLPrice"].ToString();
                dr["PLDaysCovered"] = r["PLDaysCovered"];
                newDt.Rows.Add(dr);
            }

            guna2DataGridView1.DataSource = newDt;


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if ((txtNombre.Text == "") || (txtPrecio.Text == "") || (txtDaysCovered.Text == ""))
            {
                MessageBox.Show("Faltan datos que rellenar");
            }
            else
            {
                agregar();
            }
        }

        private void agregar()
        {
            clsAgregarPlan clsAgregar = new clsAgregarPlan();

            if (editarPlan)
            {
                clsAgregar.iPlId = int.Parse(idtemporal);
            }

            clsAgregar.sUsName = txtNombre.Text.ToString();
            clsAgregar.sPLPrice = float.Parse(txtPrecio.Text.ToString());
            clsAgregar.sPLDaysCovered = int.Parse(txtDaysCovered.Text.ToString());

            if(editarPlan == false)
            {
                //clsAgregar.sUsName = txtNombre.Text.ToString();

                if (clsAgregar.planExistente())
                {
                    MessageBox.Show("El Plan ya existe.");
                    return; // Detener la ejecución si el usuario ya existe
                }
            }

            if (clsAgregar.Guardar() == true)
            {
                MessageBox.Show("Sus datos se a Guardado correctamente");
                limpiar();
                addPlan_Load(null, null); // Vuelve a cargar los datos del DataGridView

                editarPlan = false;
            }
            else
            {
                MessageBox.Show("Sus datos no se a Guardado correctamente");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                idtemporal = guna2DataGridView1.Rows[index].Cells["PLId"].Value?.ToString();
                txtNombre.Text = guna2DataGridView1.Rows[index].Cells["PLName"].Value?.ToString();
                txtPrecio.Text = guna2DataGridView1.Rows[index].Cells["PLPrice"].Value?.ToString();
                txtDaysCovered.Text = guna2DataGridView1.Rows[index].Cells["PLDaysCovered"].Value?.ToString();

                editarPlan = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los datos: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if ((txtNombre.Text == "") || (txtPrecio.Text == "") || (txtDaysCovered.Text == ""))
            {
                MessageBox.Show("Faltan datos que rellenar");
            }
            else
            {
                eliminar();
            }
        }

        private void eliminar()
        {
            clsAgregarPlan clsAgregar = new clsAgregarPlan();

            clsAgregar.iPlId = int.Parse(idtemporal);

            if (clsAgregar.Eliminar() == true)
            {
                MessageBox.Show("Sus datos se eliminaron correctamente");
                limpiar();
                addPlan_Load(null, null); // Vuelve a cargar los datos del DataGridView

                editarPlan = false;
            }
            else
            {
                MessageBox.Show("Sus datos no se a eliminado correctamente");
            }
        }

        private void limpiar()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtDaysCovered.Clear();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla presionada
            }
        }

        private void txtDaysCovered_KeyPress(object sender, KeyPressEventArgs e)
        {
             // Solo permite números y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla presionada
            }
        }

    }
}
