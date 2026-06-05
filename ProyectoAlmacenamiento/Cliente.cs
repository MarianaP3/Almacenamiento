using ProyectoAlmacenamiento.DBController;
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

namespace ProyectoAlmacenamiento
{
    public partial class Cliente : Form
    {

        SqlConnection nuevaConexion = Conexion.GetConnection();

        string IdCliente = "";
        string nombre_cliente = "";
        string telefono_cliente = "";
        string correo_cliente = "";
        String telefono = "";
        String correo = "";
        public Cliente()
        {
            InitializeComponent();
            ConsultaDatos();
        }

        public void ConsultaDatos()
        {
            nuevaConexion.Open();
            TablaCliente.DataSource = null;
            String selectInfo = "SELECT * FROM logistica.Cliente";
            SqlCommand scm = new SqlCommand(selectInfo, nuevaConexion);
            SqlDataReader lector = scm.ExecuteReader();

            if (TablaCliente.Columns.Count == 0)
            {
                TablaCliente.Columns.Add("IdCliente", "ID");
                TablaCliente.Columns.Add("Nombre_cliente", "Nombre");
                TablaCliente.Columns.Add("Telefono_cliente", "Teléfono");
                TablaCliente.Columns.Add("Correo_cliente", "Correo");
            }

            TablaCliente.Rows.Clear();

            int i = 0;
            while (lector.Read())
            {
                TablaCliente.Rows.Add();
                TablaCliente.Rows[i].Cells[0].Value = lector["IdCliente"].ToString();
                TablaCliente.Rows[i].Cells[1].Value = lector["NombreCliente"].ToString();
                TablaCliente.Rows[i].Cells[2].Value = lector["TelefonoCliente"].ToString();
                TablaCliente.Rows[i].Cells[3].Value = lector["CorreoCliente"].ToString();
                i++;
            }

            lector.Close();
            nuevaConexion.Close();
        }



        public void InsertaDato()
        {
            nombre_cliente = textNombre_Cliente.Text;
            telefono_cliente = textTelefono_Cliente.Text;
            correo_cliente = textCorreo_Cliente.Text;

            nuevaConexion.Open();

            // Verificar si el correo ya existe
            if (CorreoExiste(correo_cliente, nuevaConexion))
            {
                MessageBox.Show("El correo ya está registrado.");
            }
            else if (TelefonoExiste(telefono_cliente, nuevaConexion)) // Verificar si el teléfono ya existe
            {
                MessageBox.Show("El teléfono ya está registrado.");
            }
            else
            {
                string insertInfo = "INSERT INTO logistica.Cliente(NombreCliente, " +
                "TelefonoCliente, CorreoCliente ) VALUES ('" + nombre_cliente + "'," +
         "'" + telefono_cliente + "','" + correo_cliente + "' )";

                SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
                cm.ExecuteNonQuery();
            }

            nombre_cliente = "";
            telefono_cliente = "";
            correo_cliente = "";


            nuevaConexion.Close();
        }


        // Función para verificar si el correo ya existe en la base de datos
        public bool CorreoExiste(string correo, SqlConnection conexion)
        {
            string query = "SELECT COUNT(1) FROM logistica.Cliente WHERE CorreoCliente = @Correo";

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
            string query = "SELECT COUNT(1) FROM logistica.Cliente WHERE TelefonoCliente = @Telefono";

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
            nombre_cliente = textNombre_Cliente.Text;
            telefono_cliente = textTelefono_Cliente.Text;
            correo_cliente = textCorreo_Cliente.Text;

            nuevaConexion.Open();

            // que cheque que se modificó

            bool modificoCorreo = correo.Equals(correo_cliente);
            bool modificoTelefono = telefono.Equals(telefono_cliente);

            if (CorreoExiste(correo_cliente, nuevaConexion) && !modificoCorreo)
            {
                MessageBox.Show("El correo ya está registrado.");
            }
            else if (TelefonoExiste(telefono_cliente, nuevaConexion) && !modificoTelefono) // Verificar si el teléfono ya existe
            {
                MessageBox.Show("El teléfono ya está registrado.");
            }
            else
            {
                string insertInfo = "UPDATE logistica.Cliente SET NombreCliente = '" + nombre_cliente + "', TelefonoCliente = '" +
                   telefono_cliente + "', CorreoCliente = '" + correo_cliente + "' WHERE IdCliente = '" + IdCliente + "'";

                SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
                cm.ExecuteNonQuery();
            }

            nombre_cliente = "";
            telefono_cliente = "";
            correo_cliente = "";

            nuevaConexion.Close();

        }

        private void RemoverDato()
        {

            nuevaConexion.Open();

            string insertInfo = "DELETE FROM logistica.Cliente WHERE IdCliente = '" + IdCliente + "'";

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
            IdCliente = "";
            textNombre_Cliente.Clear();
            textTelefono_Cliente.Clear();
            textCorreo_Cliente.Clear();
        }

        private void botonClickModificar_Click(object sender, EventArgs e)
        {
            ModificarDato(telefono, correo);
            ConsultaDatos();
            IdCliente = "";
            textNombre_Cliente.Clear();
            textTelefono_Cliente.Clear();
            textCorreo_Cliente.Clear();
        }

        private void botonClickInsertar_Click(object sender, EventArgs e)
        {
            InsertaDato();
            ConsultaDatos();
            textNombre_Cliente.Clear();
            textTelefono_Cliente.Clear();
            textCorreo_Cliente.Clear();
        }

        private void TablaCliente_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén la marca seleccionada
                DataGridViewRow filaSeleccionada = TablaCliente.Rows[e.RowIndex];

                // Obtén el valor de una celda específica (por ejemplo, la primera transporte)
                IdCliente = filaSeleccionada.Cells[0].Value.ToString();
                textNombre_Cliente.Text = filaSeleccionada.Cells[1].Value.ToString();
                textTelefono_Cliente.Text = filaSeleccionada.Cells[2].Value.ToString();
                textCorreo_Cliente.Text = filaSeleccionada.Cells[3].Value.ToString();
                telefono = filaSeleccionada.Cells[2].Value.ToString();
                correo = filaSeleccionada.Cells[3].Value.ToString();

            }
        }
    }
}