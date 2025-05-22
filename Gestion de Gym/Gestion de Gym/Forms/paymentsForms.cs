using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion_de_Gym.Clases;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using System.Globalization;
using ClosedXML.Excel;
using System.IO;

namespace Gestion_de_Gym.Forms
{
    public partial class paymentsForms : Form
    {
        clsAgregarPago clsAgregar = new clsAgregarPago();

        public string idtemporal;
        public string idMember;
        public bool editarPay = false;
        private int diasVarcados = 0;

        private int index = 0;
        private int selectedRowIndex = -1;
        public paymentsForms()
        {
            InitializeComponent();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            this.Hide();
            loginForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
            mainForm mainForm = new mainForm();
            this.Hide();
            mainForm.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            viewMemberForm viewMemberForm = new viewMemberForm();
            this.Hide();
            viewMemberForm.Show();
        }

        private void paymentsForms_Load(object sender, EventArgs e)
        {

            if (clsAgregarPago.DatosPay != null)
            {
                idMember = clsAgregarPago.DatosPay.iPId.ToString();
                txtName.Text = clsAgregarPago.DatosPay.NameMember.ToString();
            }


            rellenarComboBox();

            rellenarTabla();

        }

        public void rellenarTabla()
        {

            //DataTable dt = clsAgregar.ConsultarTodos(); // Este método llama a SP_Paytbl con @OP = 6

            //// Verificamos y agregamos columnas si aún no existen (aunque en general el DataTable ya debe venir con estos nombres)
            //if (!dt.Columns.Contains("PId")) dt.Columns.Add("PId", typeof(string));
            //if (!dt.Columns.Contains("PAmount")) dt.Columns.Add("PAmount", typeof(string));
            //if (!dt.Columns.Contains("MName")) dt.Columns.Add("MName", typeof(string));
            //if (!dt.Columns.Contains("PLName")) dt.Columns.Add("PLName", typeof(string));
            //if (!dt.Columns.Contains("PStartDate")) dt.Columns.Add("PStartDate", typeof(string));
            //if (!dt.Columns.Contains("PEndData")) dt.Columns.Add("PEndData", typeof(string));

            //// Clonamos la estructura para crear un nuevo DataTable (esto es útil si necesitas modificar los datos o el orden)
            //DataTable newDt = dt.Clone();

            //// Rellenamos el nuevo DataTable con los valores convertidos a string (o con el formato deseado)
            //foreach (DataRow r in dt.Rows)
            //{
            //    DataRow dr = newDt.NewRow();
            //    dr["PId"] = r["PId"].ToString();
            //    dr["PAmount"] = r["PAmount"].ToString();
            //    dr["MName"] = r["MName"].ToString();
            //    dr["PLName"] = r["PLName"].ToString();
            //    dr["PStartDate"] = r["PStartDate"].ToString();
            //    dr["PEndData"] = r["PEndData"].ToString();
            //    newDt.Rows.Add(dr);
            //}

            //// Finalmente, asignamos el DataTable al DataGridView
            //guna2DataGridView1.DataSource = newDt;


            // ----- intenta mostrar los dastos del mes que pertenese por ejemplo ya no apareceran los datos del mes anterior
            // pero si lo de actual mes -------------------------------------------------------------------------------------

            DataTable dt = clsAgregar.ConsultarTodos(); // Llama al SP_Paytbl con @OP = 6

            if (!dt.Columns.Contains("PId")) dt.Columns.Add("PId", typeof(string));
            if (!dt.Columns.Contains("PAmount")) dt.Columns.Add("PAmount", typeof(string));
            if (!dt.Columns.Contains("MName")) dt.Columns.Add("MName", typeof(string));
            if (!dt.Columns.Contains("PLName")) dt.Columns.Add("PLName", typeof(string));
            if (!dt.Columns.Contains("PStartDate")) dt.Columns.Add("PStartDate", typeof(string));
            if (!dt.Columns.Contains("PEndData")) dt.Columns.Add("PEndData", typeof(string));

            DataTable newDt = dt.Clone();

            DateTime now = DateTime.Now;
            int currentMonth = now.Month;
            int currentYear = now.Year;

            foreach (DataRow r in dt.Rows)
            {
                // Intenta convertir PStartDate a DateTime
                if (DateTime.TryParse(r["PStartDate"].ToString(), out DateTime fechaInicio))
                {
                    // Solo incluir si es del mes y año actual
                    if (fechaInicio.Month == currentMonth && fechaInicio.Year == currentYear)
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
                }
            }

            guna2DataGridView1.DataSource = newDt;

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                idtemporal = guna2DataGridView1.Rows[e.RowIndex].Cells["PId"].Value?.ToString();


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

        public void rellenarComboBox()
        {
            clsAgregarPlan clsAgregar = new clsAgregarPlan();
            DataTable dt = clsAgregar.Consultar();

            // Agregar una fila vacía al inicio
            DataRow filaVacia = dt.NewRow();
            filaVacia["PLId"] = DBNull.Value; // O usa un valor que indique vacío
            filaVacia["PLName"] = "Elige un opcion";
            dt.Rows.InsertAt(filaVacia, 0);

            if (dt.Rows.Count > 0)
            {
                cbMes.ValueMember = "PLId";
                cbMes.DisplayMember = "PLName";
                cbMes.DataSource = dt;

            }
            else
            {
                MessageBox.Show("No se encontraron datos para llenar el ComboBox.");
            }


        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMes.SelectedIndex != -1 && cbMes.SelectedValue != null && cbMes.SelectedValue.ToString() != "")
            {
                clsAgregarPlan clsAgregar = new clsAgregarPlan();
                DataTable dt = clsAgregar.Consultar();

                DataRow[] filaSeleccionada = dt.Select($"PLId = {cbMes.SelectedValue}");

                if (filaSeleccionada.Length > 0)
                {
                    txtMonto.Text = filaSeleccionada[0]["PLPrice"].ToString();
                    diasVarcados = Convert.ToInt32(filaSeleccionada[0]["PLDaysCovered"]);
                }
                else
                {
                    txtMonto.Text = "Precio no encontrado";
                }

            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if ((txtName.Text == "") || (cbMes.Text == "") || (txtMonto.Text == " "))
            {
                MessageBox.Show("Faltan datos que rellenar");
            }
            else
            {
                guardar();
            }
        }

        public void guardar()
        {
            DateTime fechaInicio = DateTime.Now;
            DateTime fechaFinal = fechaInicio.AddDays(diasVarcados);

            if (editarPay == true)
            {
                clsAgregar.iPId = int.Parse(idtemporal);
            }

            clsAgregar.iPMemberId = int.Parse(idMember);
            clsAgregar.iPPlanId = Convert.ToInt32(cbMes.SelectedValue);
            clsAgregar.sPAmount = decimal.Parse(txtMonto.Text);
            clsAgregar.sPEndData = fechaFinal.Date;

            if (clsAgregar.Guardar() == true)
            {
                MessageBox.Show("Sus datos se a Guardado correctamente");
                rellenarTabla();
                limpiar();
            }
            
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        public void limpiar()
        {
            txtName.Clear();
            cbMes.SelectedIndex = -1;
            txtMonto.Clear();
            idtemporal = null;
        }

        private void btnDeleter_Click(object sender, EventArgs e)
        {
            if (idtemporal == null)
            {
                MessageBox.Show("Seleciona el pago");
            }
            else
            {
                eliminar();
                rellenarTabla();
                
            }
        }

        public void eliminar()
        {
            clsAgregar.iPId = int.Parse(idtemporal);

            if (clsAgregar.Eliminar() == true)
            {
                limpiar();
                MessageBox.Show("Sus datos se eliminaron correctamente");
            }
            else
            {
                MessageBox.Show("Sus datos no se a eliminado correctamente");
            }
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecciona la carpeta donde guardar los archivos";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string basePath = folderDialog.SelectedPath;

                    // Aquí va tu código para crear carpetas y guardar archivos dentro de basePath
                    ExportarDatos(basePath);
                }
                else
                {
                    MessageBox.Show("No se seleccionó ninguna carpeta.");
                }
            }
        }



        private void ExportarDatos(string basePath)
        {
            Directory.CreateDirectory(basePath);

            DataTable dt = clsAgregar.ConsultarTodos();

            // Asegurarse de que las columnas necesarias existen
            string[] columnas = { "PId", "PAmount", "MName", "PLName", "PStartDate", "PEndData" };
            foreach (string col in columnas)
                if (!dt.Columns.Contains(col)) dt.Columns.Add(col, typeof(string));

            // Agrupar por año y mes, y tomar los últimos 3 meses
            var grupos = dt.AsEnumerable()
                .Where(r => DateTime.TryParse(r["PStartDate"].ToString(), out _))
                .GroupBy(r =>
                {
                    DateTime fecha = DateTime.Parse(r["PStartDate"].ToString());
                    return new { Año = fecha.Year, Mes = fecha.Month };
                })
                .OrderByDescending(g => new DateTime(g.Key.Año, g.Key.Mes, 1))
                .Take(3);

            foreach (var grupo in grupos)
            {
                // Crear carpeta del mes
                string folderName = Path.Combine(basePath, $"{grupo.Key.Año}-{grupo.Key.Mes:D2}");
                Directory.CreateDirectory(folderName);

                // Crear DataTable con solo las columnas deseadas (sin PStartDate)
                DataTable mesTable = new DataTable();
                mesTable.Columns.Add("PId", typeof(string));
                mesTable.Columns.Add("PAmount", typeof(string));
                mesTable.Columns.Add("MName", typeof(string));
                mesTable.Columns.Add("PLName", typeof(string));
                mesTable.Columns.Add("PEndData", typeof(string));

                // Copiar datos
                foreach (var row in grupo)
                {
                    DataRow newRow = mesTable.NewRow();
                    newRow["PId"] = row["PId"];
                    newRow["PAmount"] = row["PAmount"];
                    newRow["MName"] = row["MName"];
                    newRow["PLName"] = row["PLName"];
                    newRow["PEndData"] = row["PEndData"];
                    mesTable.Rows.Add(newRow);
                }

                // Guardar archivo Excel
                using (var wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(mesTable, "Datos");
                    string filePath = Path.Combine(folderName, $"Pagos_{grupo.Key.Año}-{grupo.Key.Mes:D2}.xlsx");
                    wb.SaveAs(filePath);
                }
            }

            MessageBox.Show("Exportación completada.");

        }



    }
}



