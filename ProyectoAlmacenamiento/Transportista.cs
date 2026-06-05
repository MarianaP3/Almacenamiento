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
    public partial class Transportista : Form
    {

        SqlConnection nuevaConexion = Conexion.GetConnection();

        string IdTransportista = "";
        string nombre_transportista = "";
        string telefono_transportista = "";
        string correo_transportista = "";
        string horaentrada_transportista = "";
        string horasalida_transportista = "";
        String telefono = "";
        String correo = "";
        public Transportista()
        {
            InitializeComponent();
            TimeSalida.Format = DateTimePickerFormat.Custom;
            TimeEntrada.Format = DateTimePickerFormat.Custom;
            TimeSalida.CustomFormat = "HH:mm";
            TimeEntrada.CustomFormat = "HH:mm";
            TimeSalida.ShowUpDown = true;  // Esto oculta el calendario y solo permite seleccionar la hora.
            TimeEntrada.ShowUpDown = true;
            TimeEntrada.Value = DateTime.Today.AddHours(00).AddMinutes(00);
            TimeSalida.Value = DateTime.Today.AddHours(00).AddMinutes(00);
            ConsultaDatos();

        }

        private void TimeSalida_ValueChanged(object sender, EventArgs e)
        {
           

        }

        public void ConsultaDatos()
        {
            nuevaConexion.Open();
            TablaTransportista.DataSource = null;
            String selectInfo = "SELECT * FROM logistica.Transportista";
            SqlCommand scm = new SqlCommand(selectInfo, nuevaConexion);
            SqlDataReader lector = scm.ExecuteReader();

            if (TablaTransportista.Columns.Count == 0)
            {
                TablaTransportista.Columns.Add("IdTransportista", "ID");
                TablaTransportista.Columns.Add("Nombre_transportista", "Nombre");
                TablaTransportista.Columns.Add("Telefono_transportista", "Teléfono");
                TablaTransportista.Columns.Add("Correo_transportista", "Correo");
                TablaTransportista.Columns.Add("HoraEntrada_transportista", "Hora de Entrada");
                TablaTransportista.Columns.Add("HoraSalida_transportista", "Hora de Salida");
            }

            TablaTransportista.Rows.Clear();

            int i = 0;
            while (lector.Read())
            {
                TablaTransportista.Rows.Add();
                TablaTransportista.Rows[i].Cells[0].Value = lector["IdTransportista"].ToString();
                TablaTransportista.Rows[i].Cells[1].Value = lector["NombreTransportista"].ToString();
                TablaTransportista.Rows[i].Cells[2].Value = lector["TelefonoTransportista"].ToString();
                TablaTransportista.Rows[i].Cells[3].Value = lector["CorreoTransportista"].ToString();
                TablaTransportista.Rows[i].Cells[4].Value = lector["HoraEntrada"].ToString();
                TablaTransportista.Rows[i].Cells[5].Value = lector["HoraSalida"].ToString();

                i++;
            }

            lector.Close();
            nuevaConexion.Close();
        }

        public void InsertaDato()
        {
            nombre_transportista = textNombre_Transportista.Text;
            telefono_transportista = textTelefono_Transportista.Text;
            correo_transportista = textCorreo_Transportista.Text;
            DateTime selectedTime = TimeEntrada.Value;
            DateTime selectedTime2 = TimeSalida.Value;
            horaentrada_transportista = selectedTime.ToString("HH:mm"); 
            horasalida_transportista  = selectedTime2.ToString("HH:mm");


            nuevaConexion.Open();

            // Verificar si el correo ya existe
            if (CorreoExiste(correo_transportista, nuevaConexion))
            {
                MessageBox.Show("El correo ya está registrado.");
            }
            else if (TelefonoExiste(telefono_transportista, nuevaConexion)) // Verificar si el teléfono ya existe
            {
                MessageBox.Show("El teléfono ya está registrado.");
            }
            else
            {
                string insertInfo = "INSERT INTO logistica.Transportista(NombreTransportista, " +
                "TelefonoTransportista, CorreoTransportista, HoraEntrada, HoraSalida) VALUES ('" + nombre_transportista + "'," +
                "'" + telefono_transportista + "','" + correo_transportista + "' , '" + horaentrada_transportista + "' , '" + horasalida_transportista + "' )";

                SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
                cm.ExecuteNonQuery();
            }

            nombre_transportista = "";
            telefono_transportista = "";
            correo_transportista = "";
            horaentrada_transportista = "";
            horasalida_transportista = "";

            nuevaConexion.Close();
        }

        public bool CorreoExiste(string correo, SqlConnection conexion)
        {
            string query = "SELECT COUNT(1) FROM  logistica.Transportista WHERE CorreoTransportista = @Correo";

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
            string query = "SELECT COUNT(1) FROM  logistica.Transportista WHERE TelefonoTransportista = @Telefono";

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


        private void ModificarDato()
        {
            nombre_transportista = textNombre_Transportista.Text;
            telefono_transportista = textTelefono_Transportista.Text;
            correo_transportista = textCorreo_Transportista.Text;
            DateTime selectedTime = TimeEntrada.Value;
            DateTime selectedTime2 = TimeSalida.Value;
            horaentrada_transportista = selectedTime.ToString("HH:mm");
            horasalida_transportista = selectedTime2.ToString("HH:mm");



            nuevaConexion.Open();


            // que cheque que se modificó

            bool modificoCorreo = correo.Equals(correo_transportista);
            bool modificoTelefono = telefono.Equals(telefono_transportista);

            if (CorreoExiste(correo_transportista, nuevaConexion) && !modificoCorreo)
            {
                MessageBox.Show("El correo ya está registrado.");
            }
            else if (TelefonoExiste(telefono_transportista, nuevaConexion) && !modificoTelefono) // Verificar si el teléfono ya existe
            {
                MessageBox.Show("El teléfono ya está registrado.");
            }
            else
            {

                string insertInfo = "UPDATE logistica.Transportista SET NombreTransportista = '" + nombre_transportista + "', TelefonoTransportista = '" +
             telefono_transportista + "', CorreoTransportista = '" + correo_transportista + "', HoraEntrada = '" + horaentrada_transportista + "', HoraSalida = '" + horasalida_transportista
             + "' WHERE IdTransportista = '" + IdTransportista + "'";

            SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
            cm.ExecuteNonQuery();
              }

            nombre_transportista = "";
            telefono_transportista = "";
            correo_transportista = "";
            horaentrada_transportista = "";
            horasalida_transportista = "";

            nuevaConexion.Close();


        }

        private void RemoverDato()
        {

            nuevaConexion.Open();

            string insertInfo = "DELETE FROM logistica.Transportista WHERE IdTransportista = '" + IdTransportista + "'";

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
            IdTransportista = "";
            textNombre_Transportista.Clear();
            textTelefono_Transportista.Clear();
            textCorreo_Transportista.Clear();
            TimeEntrada.Value = DateTime.Today.AddHours(00).AddMinutes(00);
            TimeSalida.Value = DateTime.Today.AddHours(00).AddMinutes(00);


        }

        private void botonClickModificar_Click(object sender, EventArgs e)
        {

            ModificarDato();
            ConsultaDatos();
            IdTransportista = "";
            textNombre_Transportista.Clear();
            textTelefono_Transportista.Clear();
            textCorreo_Transportista.Clear();
            TimeEntrada.Value = DateTime.Today.AddHours(00).AddMinutes(00);
            TimeSalida.Value = DateTime.Today.AddHours(00).AddMinutes(00);
        }

        private void botonClickInsertar_Click(object sender, EventArgs e)
        {
            InsertaDato();
            ConsultaDatos();
            textNombre_Transportista.Clear();
            textTelefono_Transportista.Clear();
            textCorreo_Transportista.Clear();
            TimeEntrada.Value = DateTime.Today.AddHours(00).AddMinutes(00);
            TimeSalida.Value = DateTime.Today.AddHours(00).AddMinutes(00);
        }

        private void TablaTransportista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén la marca seleccionada
                DataGridViewRow filaSeleccionada = TablaTransportista.Rows[e.RowIndex];

                // Obtén el valor de una celda específica (por ejemplo, la primera transporte)
                IdTransportista = filaSeleccionada.Cells[0].Value.ToString();
                textNombre_Transportista.Text = filaSeleccionada.Cells[1].Value.ToString();
                textTelefono_Transportista.Text = filaSeleccionada.Cells[2].Value.ToString();
                textCorreo_Transportista.Text = filaSeleccionada.Cells[3].Value.ToString();
                TimeEntrada.Value = Convert.ToDateTime(filaSeleccionada.Cells[4].Value.ToString());
                TimeSalida.Value = Convert.ToDateTime(filaSeleccionada.Cells[5].Value.ToString());
                telefono = filaSeleccionada.Cells[2].Value.ToString();
                correo = filaSeleccionada.Cells[3].Value.ToString();



            }
        }

        private void Transportista_Load(object sender, EventArgs e)
        {

        }
    }
}
