using ProyectoAlmacenamiento.DBController;
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

namespace ProyectoAlmacenamiento
{
    public partial class DetalleEntrega : Form
    {
        SqlConnection nuevaConexion = Conexion.GetConnection();

        string idEntrega = "", idAlmacenamiento = "";
        string idAlmacenamientoSeleccionado = "";

        DateTime? FechaCompara = null;
        public DetalleEntrega()
        {
            InitializeComponent();
            CargaEntrega();
            ConsultaDatos();

            TablaDetalleEntrega.Columns[0].Width = 150;
            TablaDetalleEntrega.Columns[1].Width = 160;
            TablaDetalleEntrega.Columns[2].Width = 160;
        }

        private void ConsultaDatos()
        {
            try
            {
                nuevaConexion.Open();
                TablaDetalleEntrega.DataSource = null; // Limpia el DataGridView

                string query = "SELECT AlmacenamientoProducto.IdAlmacenamiento, NombreProducto, Producto.IdProducto, AlmacenamientoProducto.FechaEntrega, Entrega.IdEntrega, " +
                               "NombreTransportista, Ruta.HoraSalida, DetalleEntrega.FechaReporte " +
                               "FROM logistica.DetalleEntrega " +
                               "INNER JOIN logistica.Entrega ON DetalleEntrega.IdEntrega = Entrega.IdEntrega " +
                               "INNER JOIN logistica.Ruta ON Entrega.IdRuta = Ruta.IdRuta " +
                               "INNER JOIN logistica.Transportista ON Ruta.IdTransportista = Transportista.IdTransportista " +
                               "INNER JOIN almacen.AlmacenamientoProducto ON AlmacenamientoProducto.IdAlmacenamiento = DetalleEntrega.IdAlmacenamiento " +
                               "INNER JOIN almacen.Producto ON AlmacenamientoProducto.IdProducto = Producto.IdProducto";

                SqlCommand scm = new SqlCommand(query, nuevaConexion);
                SqlDataReader lector = scm.ExecuteReader();

                if (TablaDetalleEntrega.Columns.Count == 0)
                {
                    TablaDetalleEntrega.Columns.Add("IdAlmacenamiento", "Almacenamiento");
                    TablaDetalleEntrega.Columns.Add("IdEntrega", "Entrega");
                    TablaDetalleEntrega.Columns.Add("FechaReporte", "Fecha"); // Nueva columna
                }

                TablaDetalleEntrega.Rows.Clear(); // Limpia las filas del DataGridView

                while (lector.Read())
                {
                    string IdAlmacenamiento = lector["IdAlmacenamiento"].ToString();

                    string NombreProducto = lector["NombreProducto"].ToString();
                    string IdProducto = lector["IdProducto"].ToString();
                    string FechaEntrega = DateTime.Parse(lector["FechaEntrega"].ToString()).ToString("yyyy-MM-dd");
                    string IdEntrega = lector["IdEntrega"].ToString();
                    string nombreTransportista = lector["NombreTransportista"].ToString();
                    string horaSalida = DateTime.Parse(lector["HoraSalida"].ToString()).ToString("HH:mm");
                    string fechaReporte = DateTime.Parse(lector["FechaReporte"].ToString()).ToString("yyyy-MM-dd HH:mm");

                    string infoAlmacenamiento = $"{IdAlmacenamiento} - {IdProducto} - {NombreProducto} - {FechaEntrega}";
                    string infoEntrega = $"{IdEntrega} - {nombreTransportista} ({horaSalida})";

                    // Agrega los datos al DataGridView
                    TablaDetalleEntrega.Rows.Add(infoAlmacenamiento, infoEntrega, fechaReporte);
                }

                lector.Close();
                nuevaConexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void CargaAlmacenamiento()
        {
            if (FechaCompara != null)
            {
                try
                {
                    nuevaConexion.Open();

                    // Consulta para obtener los datos
                    string selectInfo = "SELECT AlmacenamientoProducto.IdAlmacenamiento, AlmacenamientoProducto.IdProducto, Producto.NombreProducto, FechaEntrega " +
                                        "FROM almacen.AlmacenamientoProducto " +
                                        "INNER JOIN almacen.Producto " +
                                        "ON AlmacenamientoProducto.IdProducto = Producto.IdProducto " +
                                        "WHERE FechaSalida = @FechaEntrega";

                    SqlCommand cmd = new SqlCommand(selectInfo, nuevaConexion);
                    cmd.Parameters.AddWithValue("@FechaEntrega", FechaCompara);

                    SqlDataReader lector = cmd.ExecuteReader();

                    // Almacenar temporalmente los datos del lector
                    List<KeyValuePair<string, string>> datos = new List<KeyValuePair<string, string>>();

                    while (lector.Read())
                    {
                        string IdAlmacenamiento = lector["IdAlmacenamiento"].ToString();
                        string NombreProducto = lector["NombreProducto"].ToString();
                        string IdProducto = lector["IdProducto"].ToString();
                        string FechaEntrega = DateTime.Parse(lector["FechaEntrega"].ToString()).ToString("yyyy-MM-dd");

                        string infoEntrega = $"{IdAlmacenamiento} - {IdProducto} - {NombreProducto} - {FechaEntrega}";
                        datos.Add(new KeyValuePair<string, string>(IdAlmacenamiento, infoEntrega));
                    }

                    lector.Close(); // Cerrar el lector antes de realizar otras operaciones

                    // Limpiar ComboBox antes de llenarlo
                    comboBoxAlmacenamiento.Items.Clear();

                    foreach (var dato in datos)
                    {


                        if (dato.Value == idAlmacenamientoSeleccionado)
                        {

                            idAlmacenamiento = dato.Key;
                            break;
                        }
                    }

                    // Procesar los datos almacenados
                    foreach (var dato in datos)
                    {
                        string idAlmacenamiento2 = dato.Key;
                        string infoEntrega = dato.Value;

                        // Crear una nueva conexión para llamar a MismaRelacion
                        using (SqlConnection nuevaConexion2 = new SqlConnection(nuevaConexion.ConnectionString))
                        {
                            nuevaConexion2.Open();

                            if (!MismaRelacion(idAlmacenamiento2, ((KeyValuePair<string, string>)comboBoxEntrega.SelectedItem).Key, nuevaConexion2))
                            {
                                comboBoxAlmacenamiento.Items.Add(new KeyValuePair<string, string>(idAlmacenamiento2, infoEntrega));
                            }
                            nuevaConexion2.Close();
                        }
                    }

                    // Configurar cómo se mostrarán los datos en el ComboBox
                    comboBoxAlmacenamiento.DisplayMember = "Value"; // Mostrar el nombre en el ComboBox
                    comboBoxAlmacenamiento.ValueMember = "Key";     // El valor será el IdAlmacenamiento
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la ruta: " + ex.Message);
                }
                finally
                {
                    nuevaConexion.Close(); // Asegurarse de cerrar la conexión principal
                }
            }
        }



        private void CargaEntrega()
        {
            try
            {
                nuevaConexion.Open();

                String selectInfo = "SELECT IdEntrega, Transportista.NombreTransportista, Ruta.HoraSalida  " +
                   "FROM logistica.Entrega  " +
                   "INNER JOIN logistica.Ruta " +
                   "ON Entrega.IdRuta = Ruta.IdRuta " +
                   "INNER JOIN logistica.Transportista ON Ruta.IdTransportista = Transportista.IdTransportista ";

                SqlCommand cmd = new SqlCommand(selectInfo, nuevaConexion);
                SqlDataReader lector = cmd.ExecuteReader();

                comboBoxEntrega.Items.Clear();  // Limpiar ComboBox 


                while (lector.Read())
                {

                    string IdEntrega = lector["IdEntrega"].ToString();
                    string nombreTransportista = lector["NombreTransportista"].ToString();
                    string horaSalida = DateTime.Parse(lector["HoraSalida"].ToString()).ToString("HH:mm");







                    string infoAlmacenamiento = $"{IdEntrega} - {nombreTransportista} ({horaSalida})";


                    comboBoxEntrega.Items.Add(new KeyValuePair<string, string>(lector["IdEntrega"].ToString(), infoAlmacenamiento));
                }

                comboBoxEntrega.DisplayMember = "Value"; // Mostrar el nombre en el ComboBox
                comboBoxEntrega.ValueMember = "Key"; // El valor será el IdCliente

                lector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la ruta: " + ex.Message);
            }
            finally
            {
                nuevaConexion.Close();
            }
        }



        private void CargaFecha()
        {
            try
            {
                string IdEntrega = ((KeyValuePair<string, string>)comboBoxEntrega.SelectedItem).Key;

                nuevaConexion.Open();

                String selectInfo = "SELECT FechaEntrega FROM logistica.Entrega WHERE IdEntrega = @IdEntrega  ";

                SqlCommand cmd = new SqlCommand(selectInfo, nuevaConexion);
                cmd.Parameters.AddWithValue("@IdEntrega", IdEntrega);

                SqlDataReader lector = cmd.ExecuteReader();


                while (lector.Read())
                {


                    FechaCompara = DateTime.Parse(lector["FechaEntrega"].ToString());


                }



                lector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la fecha: " + ex.Message);
            }
            finally
            {
                nuevaConexion.Close();
            }
        }

        private bool MismaRelacion(string IdAlmacenamiento, string IdEntrega, SqlConnection conexion)
        {
            string query = "SELECT COUNT(1) FROM logistica.DetalleEntrega WHERE IdAlmacenamiento = @IdAlmacenamiento AND IdEntrega = @IdEntrega";

            using (SqlCommand command = new SqlCommand(query, conexion))
            {
                command.Parameters.AddWithValue("@IdEntrega", IdEntrega);
                command.Parameters.AddWithValue("@IdAlmacenamiento", IdAlmacenamiento);


                try
                {
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Si el resultado es mayor a 0, significa que ya existe
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al verificar al ingresar detalleentrega: " + ex.Message);
                    return false;
                }
            }
        }

        private void InsertaDato()
        {

            string IdEntrega = ((KeyValuePair<string, string>)comboBoxEntrega.SelectedItem).Key;
            string IdAlmacenamiento = ((KeyValuePair<string, string>)comboBoxAlmacenamiento.SelectedItem).Key;



            nuevaConexion.Open();

            if (MismaRelacion(IdAlmacenamiento, IdEntrega, nuevaConexion))
            {
                nuevaConexion.Close();
                MessageBox.Show("Ya esta registrada El almacenamiento y entrega");


                return;

            }
            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string insertInfo = "INSERT INTO logistica.DetalleEntrega (IdAlmacenamiento, IdEntrega, FechaReporte) " +
                        "VALUES (@IdAlmacenamiento, @IdEntrega, @FechaReporte)";

            SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
            cm.Parameters.AddWithValue("@IdAlmacenamiento", IdAlmacenamiento);
            cm.Parameters.AddWithValue("@IdEntrega", IdEntrega);
            cm.Parameters.AddWithValue("@FechaReporte", DateTime.Now);
            cm.ExecuteNonQuery();




            nuevaConexion.Close();

        }

        private void ModificarDato()
        {
            if (comboBoxAlmacenamiento.SelectedItem != null && comboBoxEntrega.SelectedItem != null)
            {
                string IdAlmacenamiento = ((KeyValuePair<string, string>)comboBoxAlmacenamiento.SelectedItem).Key;
                string IdEntrega = ((KeyValuePair<string, string>)comboBoxEntrega.SelectedItem).Key;

                bool modificoAlmacenamiento = IdAlmacenamiento.Equals(idAlmacenamiento);
                bool modificoEntrega = IdEntrega.Equals(idEntrega);

                nuevaConexion.Open();

                if (MismaRelacion(IdAlmacenamiento, IdEntrega, nuevaConexion) && (!modificoAlmacenamiento || !modificoEntrega))
                {
                    nuevaConexion.Close();
                    MessageBox.Show("Ya está registrada la relación entre el almacenamiento y la entrega.");
                    return;
                }

                try
                {
                    // Obtén la fecha y hora actual
                    string fechaActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    // Actualiza los datos en la base de datos
                    string updateQuery = "UPDATE logistica.DetalleEntrega " +
                                         "SET IdEntrega = @IdEntrega, IdAlmacenamiento = @IdAlmacenamiento, FechaReporte = @FechaReporte " +
                                         "WHERE IdEntrega = @IdEntregaAnterior AND IdAlmacenamiento = @IdAlmacenamientoAnterior";

                    SqlCommand cm = new SqlCommand(updateQuery, nuevaConexion);
                    cm.Parameters.AddWithValue("@IdEntrega", IdEntrega);
                    cm.Parameters.AddWithValue("@IdAlmacenamiento", IdAlmacenamiento);
                    cm.Parameters.AddWithValue("@FechaReporte", DateTime.Now);
                    cm.Parameters.AddWithValue("@IdEntregaAnterior", idEntrega);
                    cm.Parameters.AddWithValue("@IdAlmacenamientoAnterior", idAlmacenamiento);

                    cm.ExecuteNonQuery();

                    MessageBox.Show("Datos modificados correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar los datos: " + ex.Message);
                }
                finally
                {
                    nuevaConexion.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un almacenamiento y una entrega para modificar.");
            }
        }


        private void RemoverDato()
        {
            string IdAlmacenamiento = idAlmacenamiento;
            string IdEntrega = idEntrega;

            try
            {
                nuevaConexion.Open();

                // Elimina primero los registros relacionados en DetalleEntrega
                string deleteDetalleEntrega = "DELETE FROM logistica.DetalleEntrega WHERE IdAlmacenamiento = @IdAlmacenamiento AND IdEntrega = @IdEntrega";
                SqlCommand cmdDetalleEntrega = new SqlCommand(deleteDetalleEntrega, nuevaConexion);
                cmdDetalleEntrega.Parameters.AddWithValue("@IdAlmacenamiento", IdAlmacenamiento);
                cmdDetalleEntrega.Parameters.AddWithValue("@IdEntrega", IdEntrega);
                cmdDetalleEntrega.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al eliminar el registro: " + ex.Message);
            }
            finally
            {
                nuevaConexion.Close();
            }
        }

        private void botonClickEliminar_Click(object sender, EventArgs e)
        {
            RemoverDato();
            ConsultaDatos();

            LimpiarCampos();


        }

        private void botonClickModificar_Click(object sender, EventArgs e)
        {

            ModificarDato();
            ConsultaDatos();

            LimpiarCampos();
        }

        private void botonClickInsertar_Click(object sender, EventArgs e)
        {
            InsertaDato();
            ConsultaDatos();

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {

            comboBoxEntrega.SelectedIndex = -1; ;
            comboBoxAlmacenamiento.SelectedIndex = -1;
            comboBoxAlmacenamiento.Items.Clear();

        }

        private void DetalleEntrega_Load(object sender, EventArgs e)
        {

        }



        private void comboBoxEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEntrega.SelectedItem != null)
            {
                comboBoxAlmacenamiento.SelectedIndex = -1;

                CargaFecha();
                CargaAlmacenamiento();
            }

        }

        private void TablaDetalleEntrega_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén la marca seleccionada
                DataGridViewRow filaSeleccionada = TablaDetalleEntrega.Rows[e.RowIndex];

                // Obtén el valor de una celda específica (por ejemplo, la primera transporte)


                idAlmacenamientoSeleccionado = filaSeleccionada.Cells[0].Value.ToString();

                string idEntregaSeleccionado = filaSeleccionada.Cells[1].Value.ToString();

                foreach (KeyValuePair<string, string> item in comboBoxEntrega.Items)
                {



                    if (item.Value == idEntregaSeleccionado)
                    {
                        idEntrega = item.Key;

                        comboBoxEntrega.SelectedItem = item;

                        break;
                    }


                }




            }
        }


    }
}
