using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Gestion_de_Gym.Clases;
using System.Reflection;
using System.Web.ModelBinding;


namespace Gestion_de_Gym.Forms
{
    public partial class adduserForm : Form
    {
        private  int index = 0;
        private string idtemporal;
        private bool editarUser = false;
        private int selectedRowIndex = -1;


        public adduserForm()
        {
            InitializeComponent();
            //consecutivo();
        }

        //El siguiente codigo muestra datos en la tabla
        private void adduserForm_Load(object sender, EventArgs e)
        {
            button4.Enabled = false;

            clsAgregarUsasrio clsAgregar = new clsAgregarUsasrio();

            // Llama al método obtener para obtener los datos de la base de datos
            DataSet ds = clsAgregar.obtener();
            DataTable dt = new DataTable();

            dt.Columns.Add("UsId");
            dt.Columns.Add("UsName");
            dt.Columns.Add("UsRange");

            foreach(DataRow r in ds.Tables[0].Rows)
            {
                DataRow dr = dt.NewRow();
                
                dr["UsId"] = r["UsId"].ToString();
                dr["UsName"] = r["UsName"].ToString(); // Corregido el índice de la columna
                dr["UsRange"] = r["UsRange"].ToString(); // Corregido el índice de la columna
                dt.Rows.Add(dr); // Agregar la nueva fila al DataTable
            }

            // Establece el DataSource del DataGridView con el DataSet
            //guna2DataGridView1.DataSource = ds.Tables[0]; // Suponiendo que el DataSet contiene una única tabla
            guna2DataGridView1.DataSource = dt;
        }

        //El siguiente codigo seleciona la linea de la tabla que se desea editar 
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    button4.Enabled = true;  // Habilita el botón cuando se selecciona una fila
                    index = e.RowIndex;
                }
                else
                {
                    button4.Enabled = false; // Deshabilita si no hay selección válida
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

        
        //es el consecutivo que agarra el ultimo id y lo umenta 1
        //private void consecutivo()
        //{
        //    //int proximoId = 0; // Variable para almacenar el próximo ID consecutivo
        //    SqlConnection con = new SqlConnection(clsConexion.conectar());
        //    SqlCommand cmd = new SqlCommand("", con);
        //    SqlDataReader dr;

        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "SELECT ISNULL(MAX(UsId), 0) + 1 as consec FROM UserTbl";

        //    try
        //    {
        //        con.Open();
        //        dr = cmd.ExecuteReader();

        //        if (dr.Read()) // Verificar si hay filas devueltas por la consulta
        //        {
        //            idtemporal = Convert.ToString(dr["consec"]); // Obtener el próximo ID consecutivo
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error al obtener el próximo ID consecutivo: {ex.Message}");
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //   // return proximoId; // Devolver el próximo ID consecutivo obtenido de la consulta
        //}

        private bool UsuarioExiste(string nombreUsuario, string contraseña)
        {
            bool existe = false;
            SqlConnection con = new SqlConnection(clsConexion.conectar());
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM UserTbl WHERE UsName = @UsName AND UsPassword = @UsPassword", con);
            cmd.Parameters.AddWithValue("@UsName", nombreUsuario);
            cmd.Parameters.AddWithValue("@UsPassword", contraseña);

            try
            {
                con.Open();
                existe = (int)cmd.ExecuteScalar() > 0;  // Directamente asignando el resultado
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar si el usuario existe: {ex.Message}");
            }
            finally
            {
                con.Close();
            }

            return existe;
        }


        private void label3_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            this.Hide();
            loginForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainForm mainForm = new mainForm(); 
            this.Hide();
            mainForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((txtNombre.Text == "") || (txtContraseña.Text == "") || (txtConfirmarContraseña.Text == "") || (cmbRango.Text == ""))
            {
                MessageBox.Show("Faltan datos que rellenar");
            }
            else
            {
                agregar();
            }
        }

        private void btnEditar(object sender, EventArgs e)
        {
            try
            {
                idtemporal = guna2DataGridView1.Rows[index].Cells["UsId"].Value?.ToString();
                // Asignar los valores de las celdas de la fila seleccionada a los campos de texto
                txtNombre.Text = guna2DataGridView1.Rows[index].Cells["UsName"].Value?.ToString();
                cmbRango.Text = guna2DataGridView1.Rows[index].Cells["UsRange"].Value?.ToString();

                editarUser = true;

                //MessageBox.Show("Sus dato es:" + editarUser);

            }
            catch(Exception ex )
            {
                Console.WriteLine($"Error al obtener los datos: {ex.Message}");
            }
  
        }

        private void vtnEliminar(object sender, EventArgs e)
        {
            if ((txtNombre.Text == "") || (cmbRango.Text == "")) 
            {
                MessageBox.Show("no tienen datos");
            }
            else
            {
                eliminar();
            }
        }

        private void agregar()
        {
            clsAgregarUsasrio clsAgregar = new clsAgregarUsasrio();

            if (editarUser)
            {
                clsAgregar.iUsId = int.Parse(idtemporal); // Solo se asigna el ID si estamos editando
            }

            clsAgregar.sUsName = txtNombre.Text.ToString();
            clsAgregar.sUsPassword = clsEncrypt.GetSHA256(txtContraseña.Text);
            clsAgregar.sUsRange = cmbRango.Text;

            if(txtContraseña.Text != txtConfirmarContraseña.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }
            else
            {
                // Verificar si el usuario ya existe antes de guardar
                if(editarUser == false)
                {
                    if (UsuarioExiste(clsAgregar.sUsName, clsAgregar.sUsPassword))
                    {
                        MessageBox.Show("El usuario ya existe.");
                        return; // Detener la ejecución si el usuario ya existe
                    }
                }

                if (clsAgregar.Guardar() == true)
                {
                    MessageBox.Show("Sus datos se a Guardado correctamente");
                    limpiar();
                    //consecutivo();
                    adduserForm_Load(null, null); // Vuelve a cargar los datos del DataGridView

                    editarUser = false;
                }
                else
                {
                    MessageBox.Show("Sus datos no se a Guardado correctamente");
                }
            }
        }

        private void eliminar()
        {
            clsAgregarUsasrio clsAgregar = new clsAgregarUsasrio();

            clsAgregar.iUsId = int.Parse(idtemporal);

            if (clsAgregar.Eliminar() == true)
            {
                MessageBox.Show("Sus datos se eliminaron correctamente");
                limpiar();
                //consecutivo();
                adduserForm_Load(null, null); // Vuelve a cargar los datos del DataGridView

                editarUser = false;
            }
            else
            {
                MessageBox.Show("Sus datos no se eliminaron correctamente");
            }
        }

        private void limpiar()
        {
            txtNombre.Clear();
            txtContraseña.Clear();
            txtConfirmarContraseña.Clear() ;
            cmbRango.SelectedIndex = -1;

        }

        
    }
}
