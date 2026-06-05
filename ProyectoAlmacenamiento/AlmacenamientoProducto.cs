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
    public partial class AlmacenamientoProducto : Form
    {
        SqlConnection nuevaConexion = Conexion.GetConnection();
        string IdAlmacenamiento = "", ent = "", sal = "";
        public AlmacenamientoProducto()
        {

            InitializeComponent();
          
            CargaAnaquel();
            CargaProducto();
            ConsultaDatos();
            TablaAlmacen.Columns[0].Width = 40;
            TablaAlmacen.Columns[2].Width = 150;
            FechaEntrega.MinDate = DateTime.Today;
            FechaSalida.MinDate = DateTime.Today;   
        }

        public void CargaAnaquel()
        {

            try
            {
                nuevaConexion.Open();
                String selectInfo = "SELECT  IdAnaquel, Nivel, Fila, Columna FROM almacen.Anaquel";
                SqlCommand cmd = new SqlCommand(selectInfo, nuevaConexion);
                SqlDataReader lector = cmd.ExecuteReader();

                comboBoxAnaquel.Items.Clear();  // Limpiar ComboBox 

                while (lector.Read())
                {
                    // Obtener el  cliente y telefono
                    string Nivel = lector["Nivel"].ToString();
                    string Fila = lector["Fila"].ToString();
                    string Columna = lector["Columna"].ToString();

                    string cadena = $"{Nivel} - {Fila} - {Columna}";


                    comboBoxAnaquel.Items.Add(new KeyValuePair<string, string>(lector["IdAnaquel"].ToString(), cadena));
                }

                comboBoxAnaquel.DisplayMember = "Value"; // Mostrar el nombre en el ComboBox
                comboBoxAnaquel.ValueMember = "Key"; // El valor será el IdCliente

                lector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar referencias de anaquel: " + ex.Message);
            }
            finally
            {
                nuevaConexion.Close();
            }

        }

        public void CargaProducto()
        {

            try
            {
                nuevaConexion.Open();
                String selectInfo = "SELECT  IdProducto, Dimensiones, NombreProducto  FROM almacen.Producto";
                SqlCommand cmd = new SqlCommand(selectInfo, nuevaConexion);
                SqlDataReader lector = cmd.ExecuteReader();

                comboBoxProducto.Items.Clear();  // Limpiar ComboBox 

                while (lector.Read())
                {
                    // Obtener el  cliente y telefono
                    string Id = lector["IdProducto"].ToString();
                    string Dimensiones = lector["Dimensiones"].ToString();
                    string NombreProducto = lector["NombreProducto"].ToString();

                    string cadena = $"{Id} - {NombreProducto} ({Dimensiones})";


                    comboBoxProducto.Items.Add(new KeyValuePair<string, string>(lector["IdProducto"].ToString(), cadena));
                }

                comboBoxProducto.DisplayMember = "Value"; // Mostrar el nombre en el ComboBox
                comboBoxProducto.ValueMember = "Key"; // El valor será el IdCliente

                lector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar referencias de anaquel: " + ex.Message);
            }
            finally
            {
                nuevaConexion.Close();
            }

        }

        public void ConsultaDatos()
        {
            try
            {
                // Abre la conexión
                nuevaConexion.Open();
                TablaAlmacen.DataSource = null; // Limpia el DataGridView

                // Define la consulta SQL
                // Define la consulta SQL
                string selectInfo = "SELECT IdAlmacenamiento, FechaEntrega, FechaSalida, Dimensiones, AlmacenamientoProducto.IdProducto, " +
                    "NombreProducto, Nivel, Fila, Columna FROM almacen.AlmacenamientoProducto " +
                                    "INNER JOIN almacen.Producto ON AlmacenamientoProducto.IdProducto = Producto.IdProducto " +
                                    "INNER JOIN almacen.Anaquel ON AlmacenamientoProducto.IdAnaquel = Anaquel.IdAnaquel";

                SqlCommand scm = new SqlCommand(selectInfo, nuevaConexion);
                SqlDataReader lector = scm.ExecuteReader();

                // Configuración de columnas solo si es necesario
                if (TablaAlmacen.Columns.Count == 0)
                {
                    TablaAlmacen.Columns.Add("IdAlmacenamiento", "ID");
                    TablaAlmacen.Columns.Add("Anaquel", "Anaquel");
                    TablaAlmacen.Columns.Add("Producto", "Producto");
                    TablaAlmacen.Columns.Add("FechaSalida", "FechaSalida");
                    TablaAlmacen.Columns.Add("FechaEntrega", "FechaEntrega");
                    
                }

                TablaAlmacen.Rows.Clear(); // Limpia las filas del DataGridView

                int i = 0;
                while (lector.Read())
                {
                    // Obtiene y formatea los datos de cada columna
                    string IdAlmacenamiento = lector["IdAlmacenamiento"].ToString();
                    string FechaEntrega = Convert.ToDateTime(lector["FechaEntrega"]).ToString("yyyy-MM-dd");
                    string FechaSalida = Convert.ToDateTime(lector["FechaSalida"]).ToString("yyyy-MM-dd");
                    string Dimensiones = lector["Dimensiones"].ToString();
                    string IdProducto = lector["IdProducto"].ToString();
                    string NombreProducto = lector["NombreProducto"].ToString();
                    string Nivel = lector["Nivel"].ToString();
                    string Fila = lector["Fila"].ToString();
                    string Columna = lector["Columna"].ToString();

                    // Formatea las cadenas
                    string anaquel = $"{Nivel} - {Fila} - {Columna}";
                    string producto = $"{IdProducto} - {NombreProducto} ({Dimensiones})";

                    // Agrega una nueva fila con los datos formateados
                    TablaAlmacen.Rows.Add(IdAlmacenamiento, anaquel, producto, FechaSalida, FechaEntrega);

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




        private void InsertaDato()
        {

           

            string IdAnaquel = ((KeyValuePair<string, string>)comboBoxAnaquel.SelectedItem).Key;
            string IdProducto = ((KeyValuePair<string, string>)comboBoxProducto.SelectedItem).Key;

            if (ValidaConflictoFechas(IdProducto, FechaEntrega.Value, FechaSalida.Value))
            {
                MessageBox.Show("El producto ya está almacenado en este anaquel durante las fechas seleccionadas.");
                return;
            }
           



            nuevaConexion.Open();

            if (ComparaFechas(FechaSalida.Value, FechaEntrega.Value))
            {



                string insertInfo = "INSERT INTO almacen.AlmacenamientoProducto(IdAnaquel, IdProducto, FechaEntrega, FechaSalida) " +
                       "VALUES (@IdAnaquel, @IdProducto, @FechaEntrega, @FechaSalida)";
                 SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
                cm.Parameters.AddWithValue("@IdAnaquel", IdAnaquel);
                cm.Parameters.AddWithValue("@IdProducto", IdProducto);
                cm.Parameters.AddWithValue("@FechaEntrega", FechaEntrega.Value);
                cm.Parameters.AddWithValue("@FechaSalida", FechaSalida.Value);
               
                cm.ExecuteNonQuery();

            }
            else
            {
                MessageBox.Show("La fecha de salida no debe ser meyor que la fecha de regreso.");
            }

            nuevaConexion.Close();

        }




        private void ModificarDato()
        {


            if (comboBoxAnaquel.SelectedItem != null && comboBoxProducto.SelectedItem != null)
            {
                var selectedAnaquel = (KeyValuePair<string, string>)comboBoxAnaquel.SelectedItem;
                var IdAnaquel = selectedAnaquel.Key;

                var selectedProductos = (KeyValuePair<string, string>)comboBoxProducto.SelectedItem;
                var IdProducto = selectedProductos.Key;


                if (ValidaConflictoFechas(IdProducto, FechaEntrega.Value, FechaSalida.Value))
                {
                    MessageBox.Show("El producto ya está almacenado en este anaquel durante las fechas seleccionadas.");
                    return;
                }

                nuevaConexion.Open();



                if (ComparaFechas(FechaSalida.Value, FechaEntrega.Value))
                {

                    bool modificoEnt = FechaEntrega.Equals(ent);
                    bool modificoSal = FechaSalida.Equals(sal);



                    bool isMod = false;

                    if (!modificoEnt || !modificoSal)
                        isMod = true;




                    if (!isMod)
                    {
                        MessageBox.Show("El almacenamiento ya está registrado.");


                    }
                    else
                    {


                        string updateInfo = "UPDATE almacen.AlmacenamientoProducto " +
                                   "SET IdAnaquel = @IdAnaquel, IdProducto = @IdProducto, FechaEntrega = @FechaEntrega, FechaSalida = @FechaSalida " +
                                   "WHERE IdAlmacenamiento = @IdAlmacenamiento";



                        SqlCommand cm = new SqlCommand(updateInfo, nuevaConexion);
                        cm.Parameters.AddWithValue("@IdAnaquel", IdAnaquel);
                        cm.Parameters.AddWithValue("@IdProducto", IdProducto);
                        cm.Parameters.AddWithValue("@FechaEntrega", FechaEntrega.Value);
                        cm.Parameters.AddWithValue("@FechaSalida", FechaSalida.Value);
                        cm.Parameters.AddWithValue("@IdAlmacenamiento", IdAlmacenamiento);

                        cm.ExecuteNonQuery();

                        LimpiarCampos();




                    }

                }
                else
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

            string insertInfo = "DELETE FROM almacen.AlmacenamientoProducto WHERE IdAlmacenamiento = '" + IdAlmacenamiento + "'";

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

        private void TablaAlmacen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén la marca seleccionada
                DataGridViewRow filaSeleccionada = TablaAlmacen.Rows[e.RowIndex];

                // Obtén el valor de una celda específica (por ejemplo, la primera transporte)
                IdAlmacenamiento = filaSeleccionada.Cells[0].Value.ToString();

                string idAnaquelSeleccionado = filaSeleccionada.Cells[1].Value.ToString();

                foreach (KeyValuePair<string, string> item in comboBoxAnaquel.Items)
                {
                    if (item.Value == idAnaquelSeleccionado)
                    {
                        comboBoxAnaquel.SelectedItem = item;
                        break;
                    }
                }

                string idProductoSeleccionado = filaSeleccionada.Cells[2].Value.ToString();

                foreach (KeyValuePair<string, string> item in comboBoxProducto.Items)
                {
                    if (item.Value == idProductoSeleccionado)
                    {
                        comboBoxProducto.SelectedItem = item;
                        break;
                    }
                }
                try
                {
                    FechaEntrega.Value = Convert.ToDateTime(filaSeleccionada.Cells[4].Value.ToString());
                    FechaSalida.Value = Convert.ToDateTime(filaSeleccionada.Cells[3].Value.ToString());
                    ent = FechaEntrega.Text = filaSeleccionada.Cells[4].Value.ToString();
                    sal = FechaSalida.Text = filaSeleccionada.Cells[3].Value.ToString();
                } 
                catch
                {
                MessageBox.Show("No se puede cargar las Fechas anteriores");
                 }






            }
        }

        private bool ValidaConflictoFechas(string idProducto, DateTime fechaEntrega, DateTime fechaSalida)
        {
            bool conflicto = false;

            try
            {
                nuevaConexion.Open();

                string query = @"
            SELECT COUNT(*) 
FROM almacen.AlmacenamientoProducto 
WHERE IdProducto = @IdProducto 
AND (
    @FechaSalida >= FechaSalida 
    AND @FechaEntrega <= FechaEntrega  
) OR  @FechaSalida = FechaEntrega OR @FechaEntrega = FechaSalida;";
                
                SqlCommand cmd = new SqlCommand(query, nuevaConexion);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                cmd.Parameters.AddWithValue("@FechaEntrega", fechaEntrega);
                cmd.Parameters.AddWithValue("@FechaSalida", fechaSalida);

                int count = (int)cmd.ExecuteScalar();
                conflicto = count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar conflicto de fechas: " + ex.Message);
            }
            finally
            {
                nuevaConexion.Close();
            }

            return conflicto;
        }


        private bool ComparaFechas(DateTime fechaSalida, DateTime fechaEntrega)
        {
            if (fechaEntrega >= fechaSalida)
            {
                return true; // La fecha de entrada es válida
            }
            else
            {
                return false; // La fecha de entrada es inválida
            }
        }

        private void LimpiarCampos()
        {
            FechaEntrega.Value = DateTime.Now;
            FechaSalida.Value = DateTime.Now;
            comboBoxAnaquel.SelectedIndex = -1; ;
            comboBoxProducto.SelectedIndex = -1;

        }
    }
}
