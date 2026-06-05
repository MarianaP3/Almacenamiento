using ProyectoAlmacenamiento.DBController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ProyectoAlmacenamiento
{
    public partial class Ruta : Form
    {

        SqlConnection nuevaConexion = Conexion.GetConnection();
        string HoradeEntrada = "", ent = "", sal = "";
        string HoradeSalida = "";
        string IdRuta = "";
        public Ruta()
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
            CargaTransporte();
            CargaTransportista();
            TablaRuta.Columns[0].Width = 40;

        }

       

       
        public static string RestarHoras(string hora1, string hora2)
        {
            // Convertir las cadenas a TimeSpan
            TimeSpan tiempo1 = TimeSpan.Parse(hora1);
            TimeSpan tiempo2 = TimeSpan.Parse(hora2);

            // Calcular la diferencia absoluta
            TimeSpan diferencia = tiempo1 > tiempo2 ? tiempo1 - tiempo2 : tiempo2 - tiempo1;

            // Convertir la diferencia a horas decimales
            return diferencia.TotalHours.ToString("F2");
        }

        public static bool ComparaHoras(string hora1, string hora2)
        {
            // Convertir las cadenas a TimeSpan
            TimeSpan tiempo1 = TimeSpan.Parse(hora1);
            TimeSpan tiempo2 = TimeSpan.Parse(hora2);

            // Calcular la diferencia absoluta
            bool diferencia = tiempo1 < tiempo2 ;

            // Convertir la diferencia a horas decimales
            return diferencia;
        }
        public void ConsultaDatos()
        {
            try
            {
                // Abre la conexión
                nuevaConexion.Open();
                TablaRuta.DataSource = null; // Limpia el DataGridView

                // Define la consulta SQL
                // Define la consulta SQL
                string selectInfo = "SELECT Ruta.IdRuta, Transportista.NombreTransportista, Transportista.HoraEntrada, " +
                                    "Transportista.HoraSalida AS HoraSalidaTransportista, Transporte.Transporte, Transporte.Capacidad, Transporte.Modelo, " +
                                    "Ruta.HoraSalida AS HoraSalidaRuta, Ruta.HoraRegreso " +
                                    "FROM logistica.Ruta " +
                                    "INNER JOIN logistica.Transporte ON Ruta.IdTransporte = Transporte.IdTransporte " +
                                    "INNER JOIN logistica.Transportista ON Ruta.IdTransportista = Transportista.IdTransportista";

                SqlCommand scm = new SqlCommand(selectInfo, nuevaConexion);
                SqlDataReader lector = scm.ExecuteReader();

                // Configuración de columnas solo si es necesario
                if (TablaRuta.Columns.Count == 0)
                {
                    TablaRuta.Columns.Add("IdRuta", "ID");
                    TablaRuta.Columns.Add("Transportista", "Transportista");
                    TablaRuta.Columns.Add("Transporte", "Transporte");
                    TablaRuta.Columns.Add("HoraSalida", "Hora de Salida");
                    TablaRuta.Columns.Add("HoraRegreso", "Hora de Regreso");
                }

                TablaRuta.Rows.Clear(); // Limpia las filas del DataGridView

                int i = 0;
                while (lector.Read())
                {
                    // Obtiene y formatea los datos de cada columna
                    string idRuta = lector["IdRuta"].ToString();
                    string nombreTransportista = lector["NombreTransportista"].ToString();
                    string horaEnt = lector["HoraEntrada"].ToString();
                    string horaSalTransportista = lector["HoraSalidaTransportista"].ToString();
                    string nombreTransporte = lector["Transporte"].ToString();
                    string capacidad = lector["Capacidad"].ToString();
                    string modelo = lector["Modelo"].ToString();
                    string horaSalidaRuta = lector["HoraSalidaRuta"].ToString();
                    string horaRegresoRuta = lector["HoraRegreso"].ToString();

                    // Formatea las cadenas
                    string transportistaInfo = $"{nombreTransportista}({RestarHoras(horaEnt, horaSalTransportista)} horas)";
                    string transporteInfo = $"{nombreTransporte}-{modelo}({capacidad})";

                    // Agrega una nueva fila con los datos formateados
                    TablaRuta.Rows.Add(idRuta, transportistaInfo, transporteInfo, horaSalidaRuta, horaRegresoRuta);

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

        public bool HorariosSeEmpalman(string idTransportista, string nuevaHoraEntrada, string nuevaHoraSalida)
        {
            string query = @"
        SELECT HoraSalida, HoraRegreso
        FROM logistica.Ruta
        WHERE IdTransportista = @IdTransportista
        AND ((@NuevaHoraEntrada >= HoraSalida AND @NuevaHoraEntrada < HoraRegreso) 
        OR (@NuevaHoraSalida > HoraSalida AND @NuevaHoraSalida <= HoraRegreso)
        OR (HoraSalida >= @NuevaHoraEntrada AND HoraRegreso <= @NuevaHoraSalida))";

            using (SqlCommand command = new SqlCommand(query, nuevaConexion))
            {
                command.Parameters.AddWithValue("@IdTransportista", idTransportista);
                command.Parameters.AddWithValue("@NuevaHoraEntrada", nuevaHoraEntrada);
                command.Parameters.AddWithValue("@NuevaHoraSalida", nuevaHoraSalida);

                try
                {
                   SqlDataReader reader = command.ExecuteReader();
                    bool seEmpalma = reader.HasRows;
                    reader.Close();
                    return seEmpalma;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al verificar los horarios: " + ex.Message);
                    return false;
                }
               
            }
        }



        private void InsertaDato()
        {
            DateTime selectedTime = TimeEntrada.Value;
            DateTime selectedTime2 = TimeSalida.Value;
            HoradeEntrada = selectedTime.ToString("HH:mm");
            HoradeSalida = selectedTime2.ToString("HH:mm");

            string IdTransporte = ((KeyValuePair<string, string>)comboBoxTransporte.SelectedItem).Key;
            string IdTransportista = ((KeyValuePair<string, string>)comboBoxTrasportista.SelectedItem).Key;

            nuevaConexion.Open();

            try
            {
                if (ComparaHoras(HoradeSalida, HoradeEntrada))
                {
                    if (RutaExiste(IdRuta, IdTransporte, IdTransportista, HoradeEntrada, HoradeSalida, nuevaConexion))
                    {
                        MessageBox.Show("La ruta ya está registrada.");
                    }
                    else
                    {
                        if (!HorariosSeEmpalman(IdTransportista, HoradeSalida, HoradeEntrada))
                        {
                            string insertInfo = "INSERT INTO logistica.Ruta (IdTransporte, IdTransportista, HoraSalida, HoraRegreso) " +
                                                "VALUES ('" + IdTransporte + "', '" + IdTransportista + "', '" + HoradeSalida + "', '" + HoradeEntrada + "')";

                            SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
                            cm.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("La hora se sobrepone.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La hora de salida no debe ser menor que la hora de regreso.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problema con el query: " + ex.Message);
            }
            finally
            {
                nuevaConexion.Close();
            }
        }


        public void CargaTransporte()
        {

            try
            {
                nuevaConexion.Open();
                String selectInfo = "SELECT IdTransporte, Transporte, Capacidad, Modelo FROM logistica.Transporte ";
                SqlCommand cmd = new SqlCommand(selectInfo, nuevaConexion);
                SqlDataReader lector = cmd.ExecuteReader();

                comboBoxTransporte.Items.Clear();  // Limpiar ComboBox 

                while (lector.Read())
                {
                    // Obtener el  cliente y telefono
                    string nombreTransporte= lector["Transporte"].ToString();
                    string modelo = lector["Modelo"].ToString();
                    string capacidad = lector["Capacidad"].ToString();

                    string cadena= $"{nombreTransporte}-{modelo}({capacidad})";


                    comboBoxTransporte.Items.Add(new KeyValuePair<string, string>(lector["IdTransporte"].ToString(), cadena));
                }

                comboBoxTransporte.DisplayMember = "Value"; // Mostrar el nombre en el ComboBox
                comboBoxTransporte.ValueMember = "Key"; // El valor será el IdCliente

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

        public void CargaTransportista()
        {


            try
            {
                nuevaConexion.Open();
                String selectInfo = "SELECT IdTransportista, NombreTransportista, HoraEntrada, HoraSalida FROM logistica.Transportista ";
                SqlCommand cmd = new SqlCommand(selectInfo, nuevaConexion);
                SqlDataReader lector = cmd.ExecuteReader();

                comboBoxTrasportista.Items.Clear();  // Limpiar ComboBox 

                while (lector.Read())
                {
                   
                    string nombreTransportista = lector["NombreTransportista"].ToString();
                    string HoraEnt = lector["HoraEntrada"].ToString();
                    string HoraSal = lector["HoraSalida"].ToString();

          


                    string trasportistayhoras = $"{nombreTransportista}({RestarHoras(HoraEnt, HoraSal)} horas)";
            

                    comboBoxTrasportista.Items.Add(new KeyValuePair<string, string>(lector["IdTransportista"].ToString(), trasportistayhoras));
                }

                comboBoxTrasportista.DisplayMember = "Value"; // Mostrar el nombre en el ComboBox
                comboBoxTrasportista.ValueMember = "Key"; // El valor será el IdCliente

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

        public bool RutaExiste(string idRuta, string IdTransporte, string IdTransportista, string HoraEntrada, string HoraSalida, SqlConnection conexion)
        {
            string query = "SELECT COUNT(1) FROM logistica.Ruta WHERE " +
                "IdRuta =@IdRuta AND HoraRegreso = @HoraEntrada AND HoraSalida= @HoraSalida " +
                "AND IdTransporte = @IdTransporte AND IdTransportista = @IdTransportista  ";

            using (SqlCommand command = new SqlCommand(query, conexion))
            {
                command.Parameters.AddWithValue("@IdRuta", IdRuta);
                command.Parameters.AddWithValue("@HoraEntrada", HoraEntrada);
                command.Parameters.AddWithValue("@HoraSalida", HoraSalida);
                command.Parameters.AddWithValue("@IdTransportista", IdTransportista);
                command.Parameters.AddWithValue("@IdTransporte", IdTransporte);
                



                try
                {
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Si el resultado es mayor a 0, significa que ya existe
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al verificar la ruta: " + ex.Message);
                    return false;
                }
            }
        }
        private void ModificarDato()
        {
            DateTime selectedTime = TimeEntrada.Value;
            DateTime selectedTime2 = TimeSalida.Value;
            HoradeEntrada = selectedTime.ToString("HH:mm");
            HoradeSalida = selectedTime2.ToString("HH:mm");


            if (comboBoxTransporte.SelectedItem != null && comboBoxTrasportista.SelectedItem != null)
            {
                var selectedTrasporte = (KeyValuePair<string, string>)comboBoxTransporte.SelectedItem;
                var IdTransporte = selectedTrasporte.Key;

                var selectedTrasportista = (KeyValuePair<string, string>)comboBoxTrasportista.SelectedItem;
                var IdTransportista = selectedTrasportista.Key;



                nuevaConexion.Open();

                if (ComparaHoras(HoradeSalida, HoradeEntrada))
                {

                    bool modificoEnt = HoradeEntrada.Equals(ent);
                    bool modificoSal = HoradeSalida.Equals(sal);



                    bool isMod = false;

                    if (!modificoEnt || !modificoSal)
                        isMod = true;




                    if (RutaExiste(IdRuta, IdTransporte, IdTransportista, HoradeEntrada, HoradeSalida, nuevaConexion) && !isMod)
                    {
                        MessageBox.Show("La ruta ya está registrada.");


                    }
                    else
                    {
                        if (!HorariosSeEmpalman(IdTransportista, HoradeSalida, HoradeEntrada))
                        {

                            string updateInfo = "UPDATE  logistica.Ruta  SET IdTransporte = @IdTransporte, IdTransportista = @IdTransportista, HoraSalida = @HoraSalida, " +
                                            "HoraRegreso = @HoraRegreso WHERE IdRuta = @IdRuta";



                            SqlCommand cm = new SqlCommand(updateInfo, nuevaConexion);
                            cm.Parameters.AddWithValue("@IdTransporte", IdTransporte);
                            cm.Parameters.AddWithValue("@IdTransportista", IdTransportista);
                            cm.Parameters.AddWithValue("@HoraSalida", HoradeSalida);
                            cm.Parameters.AddWithValue("@HoraRegreso", HoradeEntrada);
                            cm.Parameters.AddWithValue("@IdRuta", IdRuta);

                            cm.ExecuteNonQuery();

                            LimpiarCampos();



                        }
                        else
                        {
                            MessageBox.Show("La hora se sobrepone.");
                        }

                    }

                }else
                {
                    MessageBox.Show("La hora de salida no debe ser menor que la hora de regreso.");
                }
                nuevaConexion.Close();

            }
            else
            {
                MessageBox.Show("Por favor, selecciona una ruta.");
            }
        }

        private void RemoverDato()
        {

            nuevaConexion.Open();

            string insertInfo = "DELETE FROM logistica.Ruta WHERE IdRuta = '" + IdRuta + "'";

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

        private void TablaRuta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén la marca seleccionada
                DataGridViewRow filaSeleccionada = TablaRuta.Rows[e.RowIndex];

                // Obtén el valor de una celda específica (por ejemplo, la primera transporte)
                IdRuta = filaSeleccionada.Cells[0].Value.ToString();

                string idTrasportistaSeleccionado = filaSeleccionada.Cells[1].Value.ToString();

                foreach (KeyValuePair<string, string> item in comboBoxTrasportista.Items)
                {
                    if (item.Value == idTrasportistaSeleccionado)
                    {
                        comboBoxTrasportista.SelectedItem = item;
                        break;
                    }
                }

                string idTrasporteSeleccionado = filaSeleccionada.Cells[2].Value.ToString();

                foreach (KeyValuePair<string, string> item in comboBoxTransporte.Items)
                {
                    if (item.Value == idTrasporteSeleccionado)
                    {
                        comboBoxTransporte.SelectedItem = item;
                        break;
                    }
                }

                 TimeEntrada.Value = Convert.ToDateTime(filaSeleccionada.Cells[4].Value.ToString());
                TimeSalida.Value = Convert.ToDateTime(filaSeleccionada.Cells[3].Value.ToString());
                ent = TimeEntrada.Text = filaSeleccionada.Cells[4].Value.ToString();
                sal = TimeSalida.Text = filaSeleccionada.Cells[3].Value.ToString();



            }
        }

        private void LimpiarCampos()
        {
            TimeEntrada.Value = DateTime.Today.AddHours(00).AddMinutes(00);
            TimeSalida.Value = DateTime.Today.AddHours(00).AddMinutes(00);
            comboBoxTransporte.SelectedIndex = -1; ;
            comboBoxTrasportista.SelectedIndex = -1;

        }

        private void TimeSalida_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Ruta_Load(object sender, EventArgs e)
        {

        }
    }
}