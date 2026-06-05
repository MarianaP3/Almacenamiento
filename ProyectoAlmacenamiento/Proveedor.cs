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
using ProyectoAlmacenamiento.DBController;

namespace ProyectoAlmacenamiento
{

    public partial class Proveedor : Form
    {
        SqlConnection nuevaConexion = Conexion.GetConnection();

        string IdProveedor = "";
        string nombre_proveedor = "";
        string telefono_proveedor = "";
        string correo_proveedor = "";
        string domicilio_fiscal_proveedor = "";
        String telefono = "";
        String correo = "";
        public Proveedor()
        {
            InitializeComponent();
            ConsultaDatos();
        }

        public void ConsultaDatos()
        {
            nuevaConexion.Open();
            TablaProveedor.DataSource = null;
            String selectInfo = "SELECT * FROM almacen.proveedor";
            SqlCommand scm = new SqlCommand(selectInfo, nuevaConexion);
            SqlDataReader lector = scm.ExecuteReader();

            if (TablaProveedor.Columns.Count == 0)
            {
                TablaProveedor.Columns.Add("IdProveedor", "ID");
                TablaProveedor.Columns.Add("Nombre_proveedor", "Nombre");
                TablaProveedor.Columns.Add("Telefono_proveedor", "Teléfono");
                TablaProveedor.Columns.Add("Correo_proveedor", "Correo");
                TablaProveedor.Columns.Add("Domicilio_fiscal_proveedor", "Domicilio Fiscal");
            }

            TablaProveedor.Rows.Clear();

            int i = 0;
            while (lector.Read())
            {
                TablaProveedor.Rows.Add();
                TablaProveedor.Rows[i].Cells[0].Value = lector["IdProveedor"].ToString();
                TablaProveedor.Rows[i].Cells[1].Value = lector["NombreProveedor"].ToString();
                TablaProveedor.Rows[i].Cells[2].Value = lector["TelefonoProveedor"].ToString();
                TablaProveedor.Rows[i].Cells[3].Value = lector["CorreoProveedor"].ToString();
                TablaProveedor.Rows[i].Cells[4].Value = lector["DomicilioFiscal"].ToString();
                i++;
            }

            lector.Close();
            nuevaConexion.Close();
        }

        public void InsertaDato()
        {
            nombre_proveedor = textNombre_Proveedor.Text;
            telefono_proveedor = textTelefono_Proveedor.Text;
            correo_proveedor = textCorreo_Proveedor.Text;
            domicilio_fiscal_proveedor = textDomicilio_Proveedor.Text;

            nuevaConexion.Open();

            // Verificar si el correo ya existe
            if (CorreoExiste(correo_proveedor, nuevaConexion))
            {
                MessageBox.Show("El correo ya está registrado.");
            }
            else if (TelefonoExiste(telefono_proveedor, nuevaConexion)) // Verificar si el teléfono ya existe
            {
                MessageBox.Show("El teléfono ya está registrado.");
            }
            else
            {
                string insertInfo = "INSERT INTO almacen.Proveedor(NombreProveedor, " +
                "TelefonoProveedor, CorreoProveedor, DomicilioFiscal) VALUES ('" + nombre_proveedor + "'," +
                "'" + telefono_proveedor + "','" + correo_proveedor + "' , '" + domicilio_fiscal_proveedor + "' )";

                SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
                cm.ExecuteNonQuery();
            }

            nombre_proveedor = "";
            telefono_proveedor = "";
            correo_proveedor = "";
            domicilio_fiscal_proveedor = "";

            nuevaConexion.Close();
        }

        // Función para verificar si el correo ya existe en la base de datos
        public bool CorreoExiste(string correo, SqlConnection conexion)
        {
            string query = "SELECT COUNT(1) FROM almacen.Proveedor WHERE CorreoProveedor = @Correo";

            using (SqlCommand command = new SqlCommand(query, conexion))
            {
                command.Parameters.AddWithValue("@Correo", correo);

                try
                {
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Si el resultado es mayor a 0, significa que ya existe
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al verificar el correo: " + ex.Message);
                    return false;
                }
            }
        }

        // Función para verificar si el teléfono ya existe en la base de datos
        public bool TelefonoExiste(string telefono, SqlConnection conexion)
        {
            string query = "SELECT COUNT(1) FROM almacen.Proveedor WHERE TelefonoProveedor = @Telefono";

            using (SqlCommand command = new SqlCommand(query, conexion))
            {
                command.Parameters.AddWithValue("@Telefono", telefono);

                try
                {
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Si el resultado es mayor a 0, significa que ya existe
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al verificar el teléfono: " + ex.Message);
                    return false;
                }
            }
        }

        private void ModificarDato(String telefono, String correo)
        {
            nombre_proveedor = textNombre_Proveedor.Text;
            telefono_proveedor = textTelefono_Proveedor.Text;
            correo_proveedor = textCorreo_Proveedor.Text;
            domicilio_fiscal_proveedor = textDomicilio_Proveedor.Text;

            nuevaConexion.Open();

            // que cheque que se modificó

            bool modificoCorreo = correo.Equals(correo_proveedor);
            bool modificoTelefono = telefono.Equals(telefono_proveedor);

            if (CorreoExiste(correo_proveedor, nuevaConexion) && !modificoCorreo)
            {
                MessageBox.Show("El correo ya está registrado.");
            }
            else if (TelefonoExiste(telefono_proveedor, nuevaConexion) && !modificoTelefono) // Verificar si el teléfono ya existe
            {
                MessageBox.Show("El teléfono ya está registrado.");
            }
            else
            {
                string insertInfo = "UPDATE almacen.Proveedor SET NombreProveedor = '" + nombre_proveedor + "', TelefonoProveedor = '" +
                 telefono_proveedor + "', CorreoProveedor = '" + correo_proveedor + "', DomicilioFiscal = '" + domicilio_fiscal_proveedor + "' WHERE IdProveedor = '" + IdProveedor + "'";

                SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
                cm.ExecuteNonQuery();
            }

            nombre_proveedor = "";
            telefono_proveedor = "";
            correo_proveedor = "";
            domicilio_fiscal_proveedor = "";

            nuevaConexion.Close();


        }

        private void RemoverDato()
        {
           
            nuevaConexion.Open();

            string insertInfo = "DELETE FROM almacen.Proveedor WHERE IdProveedor = '" + IdProveedor + "'";

            SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
            cm.ExecuteNonQuery();

            nuevaConexion.Close();


        }

        private void Proveedor_Load(object sender, EventArgs e)
        {

        }

        private void botonClickEliminar_Click(object sender, EventArgs e)
        {
            RemoverDato();
            ConsultaDatos();
            IdProveedor = "";
            textNombre_Proveedor.Clear();
            textTelefono_Proveedor.Clear();
            textCorreo_Proveedor.Clear();
            textDomicilio_Proveedor.Clear();
        }

        private void botonClickModificar_Click(object sender, EventArgs e)
        {
            
            ModificarDato(telefono, correo);
            ConsultaDatos();
            IdProveedor = "";
            textNombre_Proveedor.Clear();
            textTelefono_Proveedor.Clear();
            textCorreo_Proveedor.Clear();
            textDomicilio_Proveedor.Clear();
        }

        private void botonClickInsertar_Click(object sender, EventArgs e)
        {
            InsertaDato();
            ConsultaDatos();
            textNombre_Proveedor.Clear();
            textTelefono_Proveedor.Clear();
            textCorreo_Proveedor.Clear();
            textDomicilio_Proveedor.Clear();
        }

        private void TablaProveedor_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén la marca seleccionada
                DataGridViewRow filaSeleccionada = TablaProveedor.Rows[e.RowIndex];

                // Obtén el valor de una celda específica (por ejemplo, la primera transporte)
                IdProveedor = filaSeleccionada.Cells[0].Value.ToString();
                textNombre_Proveedor.Text = filaSeleccionada.Cells[1].Value.ToString();
                textTelefono_Proveedor.Text = filaSeleccionada.Cells[2].Value.ToString();
                textCorreo_Proveedor.Text = filaSeleccionada.Cells[3].Value.ToString();
                textDomicilio_Proveedor.Text = filaSeleccionada.Cells[4].Value.ToString();
                telefono = filaSeleccionada.Cells[2].Value.ToString();
                correo = filaSeleccionada.Cells[3].Value.ToString();

            }
        }
    }
}
