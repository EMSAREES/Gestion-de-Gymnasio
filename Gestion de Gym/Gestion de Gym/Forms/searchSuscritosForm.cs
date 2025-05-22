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
    public partial class searchSuscritosForm : Form
    {

        clsAgregarPago clsAgregar = new clsAgregarPago();

        private int index = 0;
        private int selectedRowIndex = -1;

        public searchSuscritosForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            this.Hide();
            loginForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mainForm mainForm = new mainForm();
            this.Hide();
            mainForm.Show();
        }

    

        private void btnSearch_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void searchSuscritosForm_Load(object sender, EventArgs e)
        {
            consultaTodo();
        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEstado.SelectedItem != null)
            {
                string estado = cbEstado.SelectedItem.ToString();

                switch (estado)
                {
                    case "Todos":
                        consultaTodo();
                        break;
                    case "Activos":
                        consultaActivos(); 
                        break;
                    case "Vencidos":
                        consultaVencidos(); 
                        break;
                }
            }
        }

        private void cbEstado_Click(object sender, EventArgs e)
        {
            // Fuerza la actualización al hacer clic en el ComboBox
            cbEstado_SelectedIndexChanged(sender, e);

        }

        private void consultaTodo()
        {

            DataTable dt = clsAgregar.ConsultarTodos(); // Este método llama a SP_Paytbl con @OP = 6

            // Verificamos y agregamos columnas si aún no existen (aunque en general el DataTable ya debe venir con estos nombres)
            if (!dt.Columns.Contains("PId")) dt.Columns.Add("PId", typeof(string));
            if (!dt.Columns.Contains("PAmount")) dt.Columns.Add("PAmount", typeof(string));
            if (!dt.Columns.Contains("MName")) dt.Columns.Add("MName", typeof(string));
            if (!dt.Columns.Contains("PLName")) dt.Columns.Add("PLName", typeof(string));
            if (!dt.Columns.Contains("PStartDate")) dt.Columns.Add("PStartDate", typeof(string));
            if (!dt.Columns.Contains("PEndData")) dt.Columns.Add("PEndData", typeof(string));

            // Clonamos la estructura para crear un nuevo DataTable (esto es útil si necesitas modificar los datos o el orden)
            DataTable newDt = dt.Clone();

            // Rellenamos el nuevo DataTable con los valores convertidos a string (o con el formato deseado)
            foreach (DataRow r in dt.Rows)
            {
                DataRow dr = newDt.NewRow();
                dr["PId"] = r["PId"].ToString();
                dr["PAmount"] = r["PAmount"].ToString();
                dr["MName"] = r["MName"].ToString();
                dr["PLName"] = r["PLName"].ToString();
                dr["PStartDate"] = r["PStartDate"].ToString();
                dr["PEndData"] = r["PEndData"].ToString();
                newDt.Rows.Add(dr);
            }

            // Finalmente, asignamos el DataTable al DataGridView
            guna2DataGridView1.DataSource = newDt;

        }

        private void consultaActivos()
        {
            DataTable dt = clsAgregar.ConsultarTodosActivos();// Este método llama a SP_Paytbl con @OP = 6

            // Verificamos y agregamos columnas si aún no existen (aunque en general el DataTable ya debe venir con estos nombres)
            if (!dt.Columns.Contains("PId")) dt.Columns.Add("PId", typeof(string));
            if (!dt.Columns.Contains("PAmount")) dt.Columns.Add("PAmount", typeof(string));
            if (!dt.Columns.Contains("MName")) dt.Columns.Add("MName", typeof(string));
            if (!dt.Columns.Contains("PLName")) dt.Columns.Add("PLName", typeof(string));
            if (!dt.Columns.Contains("PStartDate")) dt.Columns.Add("PStartDate", typeof(string));
            if (!dt.Columns.Contains("PEndData")) dt.Columns.Add("PEndData", typeof(string));

            // Clonamos la estructura para crear un nuevo DataTable (esto es útil si necesitas modificar los datos o el orden)
            DataTable newDt = dt.Clone();

            // Rellenamos el nuevo DataTable con los valores convertidos a string (o con el formato deseado)
            foreach (DataRow r in dt.Rows)
            {
                DataRow dr = newDt.NewRow();
                dr["PId"] = r["PId"].ToString();
                dr["PAmount"] = r["PAmount"].ToString();
                dr["MName"] = r["MName"].ToString();
                dr["PLName"] = r["PLName"].ToString();
                dr["PStartDate"] = r["PStartDate"].ToString();
                dr["PEndData"] = r["PEndData"].ToString();
                newDt.Rows.Add(dr);
            }

            // Finalmente, asignamos el DataTable al DataGridView
            guna2DataGridView1.DataSource = newDt;
        }

        private void consultaVencidos()
        {
            DataTable dt = clsAgregar.ConsultarTodosInactivos();// Este método llama a SP_Paytbl con @OP = 6

            // Verificamos y agregamos columnas si aún no existen (aunque en general el DataTable ya debe venir con estos nombres)
            if (!dt.Columns.Contains("PId")) dt.Columns.Add("PId", typeof(string));
            if (!dt.Columns.Contains("PAmount")) dt.Columns.Add("PAmount", typeof(string));
            if (!dt.Columns.Contains("MName")) dt.Columns.Add("MName", typeof(string));
            if (!dt.Columns.Contains("PLName")) dt.Columns.Add("PLName", typeof(string));
            if (!dt.Columns.Contains("PStartDate")) dt.Columns.Add("PStartDate", typeof(string));
            if (!dt.Columns.Contains("PEndData")) dt.Columns.Add("PEndData", typeof(string));

            // Clonamos la estructura para crear un nuevo DataTable (esto es útil si necesitas modificar los datos o el orden)
            DataTable newDt = dt.Clone();

            // Rellenamos el nuevo DataTable con los valores convertidos a string (o con el formato deseado)
            foreach (DataRow r in dt.Rows)
            {
                DataRow dr = newDt.NewRow();
                dr["PId"] = r["PId"].ToString();
                dr["PAmount"] = r["PAmount"].ToString();
                dr["MName"] = r["MName"].ToString();
                dr["PLName"] = r["PLName"].ToString();
                dr["PStartDate"] = r["PStartDate"].ToString();
                dr["PEndData"] = r["PEndData"].ToString();
                newDt.Rows.Add(dr);
            }

            // Finalmente, asignamos el DataTable al DataGridView
            guna2DataGridView1.DataSource = newDt;
        }

        private void buscar()
        {
            DataTable dt;

            if (string.IsNullOrWhiteSpace(txtPClave.Text))
            {
                // Si el TextBox está vacío, mostramos todos los miembros
                dt = clsAgregar.ConsultarTodos();
            }
            else
            {
                // Si hay texto, hacemos búsqueda por nombre
                clsAgregar.sKeyword = txtPClave.Text;
                dt = clsAgregar.BuscarPorPalabraClave();
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

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
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
    }
}
