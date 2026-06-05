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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoAlmacenamiento
{
    public partial class Entrega : Form
    {
        SqlConnection nuevaConexion = Conexion.GetConnection();
        string HoradeEntrada = "", ent = "";
        string HoradeSalida = "";
        string IdEntrega = "", Ruta = "", edo = "";

        public Entrega()
        {
            InitializeComponent();

            ConsultaDatos();
            CargaEstado();
            CargaRuta();
            TimeSalida.MinDate = DateTime.Today;
            TablaEntrega.Columns[0].Width = 40;
            TablaEntrega.Columns[1].Width = 110;

            TablaEntrega.Columns[2].Width = 110;
        }






        public void ConsultaDatos()
        {
            try
            {

                ActualizarEstadoAutomático();
                // Abre la conexión
                nuevaConexion.Open();
                TablaEntrega.DataSource = null; // Limpia el DataGridView

                // Define la consulta SQL
                // Define la consulta SQL
                String selectInfo = "SELECT IdEntrega, EstadoEntrega, TotalProductos, FechaEntrega, NombreTransportista, HoraRegreso, Ruta.HoraSalida " +
                 "FROM logistica.Entrega " +
                  "INNER JOIN logistica.Ruta ON Entrega.IdRuta = Ruta.IdRuta " +
                  "INNER JOIN logistica.Transportista " +
                 "ON Ruta.idTransportista = Transportista.idTransportista  "
                 ;


                SqlCommand scm = new SqlCommand(selectInfo, nuevaConexion);
                SqlDataReader lector = scm.ExecuteReader();

                // Configuración de columnas solo si es necesario
                if (TablaEntrega.Columns.Count == 0)
                {
                    TablaEntrega.Columns.Add("IdEntrega", "ID");
                    TablaEntrega.Columns.Add("Ruta", "Ruta");
                    TablaEntrega.Columns.Add("FechaEntrega", "Fecha de Entrega");
                    TablaEntrega.Columns.Add("Estado", "Estado");
                    TablaEntrega.Columns.Add("Totalproductos", "Total de productos");


                }

                TablaEntrega.Rows.Clear(); // Limpia las filas del DataGridView


                int i = 0;
                while (lector.Read())
                {
                    // Obtiene y formatea los datos de cada columna
                    string idEntrega = lector["IdEntrega"].ToString();


                    string fechaEntrega = Convert.ToDateTime(lector["FechaEntrega"]).ToString("yyyy-MM-dd");
                    string estado = lector["EstadoEntrega"].ToString();
                    string nombreTransportista = lector["NombreTransportista"].ToString();
                    string TotalProductos = lector["TotalProductos"].ToString();

                    // string HoraReg = lector["HoraRegreso"].ToString();
                    //  string HoraSal = lector["HoraSalida"].ToString();
                    string HoraReg = DateTime.Parse(lector["HoraRegreso"].ToString()).ToString("HH:mm");
                    string HoraSal = DateTime.Parse(lector["HoraSalida"].ToString()).ToString("HH:mm");





                    string trasportistayhoras = $"{nombreTransportista} - {HoraSal} - {HoraReg}";




                    // Agrega una nueva fila con los datos formateados
                    TablaEntrega.Rows.Add(idEntrega, trasportistayhoras, fechaEntrega, estado, TotalProductos);

                    i++;
                }

                lector.Close(); // Cierra el lector
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar datos: " + ex.Message);
            }
            finally
            {
                nuevaConexion.Close(); // Cierra la conexión
            }
        }


        public bool MismaRuta(string ruta, string FechaEntrega, SqlConnection conexion)
        {
            string query = "SELECT COUNT(1) FROM logistica.Entrega WHERE IdRuta = @IdRuta AND FechaEntrega = @FechaEntrega";

            using (SqlCommand command = new SqlCommand(query, conexion))
            {
                command.Parameters.AddWithValue("@IdRuta", ruta);
                command.Parameters.AddWithValue("@FechaEntrega", FechaEntrega);


                try
                {
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Si el resultado es mayor a 0, significa que ya existe
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al verificar al ingresar entrega: " + ex.Message);
                    return false;
                }
            }
        }

        private void InsertaDato()
        {
            string IdRuta = ((KeyValuePair<string, string>)comboBoxRuta.SelectedItem).Key;

            try
            {
                nuevaConexion.Open();

                if (MismaRuta(IdRuta, TimeSalida.Text, nuevaConexion))
                {
                    nuevaConexion.Close();
                    MessageBox.Show("Ya esta registrada Fecha y ruta");
                    return;
                }

                // Consulta de inserción
                string insertInfo = "INSERT INTO logistica.Entrega (IdRuta, FechaEntrega, EstadoEntrega, TotalProductos) VALUES ('" + IdRuta + "', '" + TimeSalida.Text + "', '" + "En proceso" + "', '" + 0 + "')";

                SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
                cm.ExecuteNonQuery();

                nuevaConexion.Close();

                ActualizarEstadoAutomático();
            }
            catch (SqlException ex)
            {
                // Si ocurre un error SQL (como por capacidad de transporte)
                MessageBox.Show("Capacidad llena del trasporte del transportista: ");
                nuevaConexion.Close();
                return;

            }

        }


        public void CargaEstado()
        {


            comboEstado.Items.Clear();  // Limpiar ComboBox 

            comboEstado.Items.Add("No entregado");
            comboEstado.Items.Add("En proceso");
            comboEstado.Items.Add("Entregado");



        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        public void CargaRuta()
        {


            try
            {
                nuevaConexion.Open();
                String selectInfo = "SELECT IdRuta, NombreTransportista, HoraRegreso, Ruta.HoraSalida " +
                   "FROM logistica.Ruta " +
                   "INNER JOIN logistica.Transportista " +
                   "ON Ruta.idTransportista = Transportista.idTransportista";
                SqlCommand cmd = new SqlCommand(selectInfo, nuevaConexion);
                SqlDataReader lector = cmd.ExecuteReader();

                comboBoxRuta.Items.Clear();  // Limpiar ComboBox 

                while (lector.Read())
                {

                    string nombreTransportista = lector["NombreTransportista"].ToString();
                    // string HoraReg = lector["HoraRegreso"].ToString();
                    //  string HoraSal = lector["HoraSalida"].ToString();
                    string HoraReg = DateTime.Parse(lector["HoraRegreso"].ToString()).ToString("HH:mm");
                    string HoraSal = DateTime.Parse(lector["HoraSalida"].ToString()).ToString("HH:mm");





                    string trasportistayhoras = $"{nombreTransportista} - {HoraSal} - {HoraReg}";


                    comboBoxRuta.Items.Add(new KeyValuePair<string, string>(lector["IdRuta"].ToString(), trasportistayhoras));
                }

                comboBoxRuta.DisplayMember = "Value"; // Mostrar el nombre en el ComboBox
                comboBoxRuta.ValueMember = "Key"; // El valor será el IdCliente

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

        private void ModificarDato()
        {



            if (comboBoxRuta.SelectedItem != null && comboEstado.SelectedItem != null)
            {


                var selectedRuta = (KeyValuePair<string, string>)comboBoxRuta.SelectedItem;
                var IdRuta = selectedRuta.Key;

                nuevaConexion.Open();


                bool modificoRuta = selectedRuta.Value.Equals(Ruta);
                bool modificoFecha = Convert.ToDateTime(TimeSalida.Value).ToString("yyyy-MM-dd").Equals(ent);
                bool modificoedo = comboEstado.SelectedItem.Equals(edo);


                bool isMod = false;

                if (!modificoFecha || !modificoRuta || !modificoedo)
                    isMod = true;





                if (MismaRuta(IdRuta, TimeSalida.Text, nuevaConexion) && isMod && modificoedo)
                {
                    nuevaConexion.Close();
                    MessageBox.Show("Ya esta registrada Fecha Y Ruta");

                    return;

                }
                /*
                                if(MismaRuta(IdRuta, TimeSalida.Text, nuevaConexion) && !modificoRuta)
                                     {
                                    nuevaConexion.Close();
                                    MessageBox.Show("Ya esta registrada Ruta");

                                    return;

                                }*/






                string updateInfo = "UPDATE  logistica.Entrega  SET IdRuta = @IdRuta, EstadoEntrega = @EstadoEntrega, FechaEntrega = @FechaEntrega " +
                                "WHERE IdEntrega = @IdEntrega";



                SqlCommand cm = new SqlCommand(updateInfo, nuevaConexion);
                cm.Parameters.AddWithValue("@IdRuta", IdRuta);
                cm.Parameters.AddWithValue("@EstadoEntrega", "En proceso");
                cm.Parameters.AddWithValue("@FechaEntrega", TimeSalida.Value);
                cm.Parameters.AddWithValue("@IdEntrega", IdEntrega);

                cm.ExecuteNonQuery();

                LimpiarCampos();




                nuevaConexion.Close();

                ActualizarEstadoAutomático();
            }


        }

        private void RemoverDato()
        {

            nuevaConexion.Open();

            string insertInfo = "DELETE FROM logistica.Entrega WHERE IdEntrega = '" + IdEntrega + "'";

            SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
            cm.ExecuteNonQuery();

            nuevaConexion.Close();


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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TablaEntrega_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén la marca seleccionada
                DataGridViewRow filaSeleccionada = TablaEntrega.Rows[e.RowIndex];

                // Obtén el valor de una celda específica (por ejemplo, la primera transporte)
                IdEntrega = filaSeleccionada.Cells[0].Value.ToString();

                string idRutaSeleccionado = filaSeleccionada.Cells[1].Value.ToString();
                Ruta = idRutaSeleccionado;

                foreach (KeyValuePair<string, string> item in comboBoxRuta.Items)
                {
                    if (item.Value == idRutaSeleccionado)
                    {
                        comboBoxRuta.SelectedItem = item;
                        break;
                    }
                }
                try
                {
                    TimeSalida.Text = filaSeleccionada.Cells[2].Value.ToString();
                }
                catch
                {
                    MessageBox.Show("No se puede cargar la Fecha anterior");
                }

                ent = filaSeleccionada.Cells[2].Value.ToString();

                comboEstado.SelectedItem = filaSeleccionada.Cells[3].Value.ToString();
                edo = filaSeleccionada.Cells[3].Value.ToString();



            }
        }



        private void LimpiarCampos()
        {

            comboEstado.SelectedIndex = -1; ;
            comboBoxRuta.SelectedIndex = -1;

        }

        private void ActualizarEstadoAutomático()
        {
            try
            {
                nuevaConexion.Open();

                // Consulta para verificar y actualizar el estado
                string query = @"
            UPDATE logistica.Entrega
            SET EstadoEntrega = CASE
                WHEN FechaEntrega <= CAST(GETDATE() AS DATE) THEN 'Entregado'
                WHEN FechaEntrega > CAST(GETDATE() AS DATE) THEN 'En proceso'
                ELSE EstadoEntrega
            END
            WHERE EstadoEntrega != 'Entregado'"; // Opcional: limitar solo a registros aún no entregados.

                SqlCommand command = new SqlCommand(query, nuevaConexion);
                int filasAfectadas = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los estados: " + ex.Message);
            }
            finally
            {
                nuevaConexion.Close();
            }
        }


    }
}

