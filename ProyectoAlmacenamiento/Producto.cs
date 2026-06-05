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
    public partial class Producto : Form
    {

        SqlConnection nuevaConexion = Conexion.GetConnection();
        string HoradeEntrada = "", ent = "", sal = "";
        string HoradeSalida = "";
        string IdProducto = "";
        public Producto()
        {
            InitializeComponent();
            ConsultaDatos();
            CargaProveedor();
            CargaDomicilioCliente();
            TablaProducto.Columns[0].Width = 40;
            TablaProducto.Columns[2].Width = 150;


        }







        public void ConsultaDatos()
        {
            try
            {
                // Abre la conexión
                nuevaConexion.Open();
                TablaProducto.DataSource = null; // Limpia el DataGridView


                // Define la consulta SQL
                string selectInfo = "SELECT Proveedor.NombreProveedor, Proveedor.TelefonoProveedor, DomicilioCliente.Calle, " +
                                 "DomicilioCliente.NumeroInterior, DomicilioCliente.NumeroExterior, Cliente.NombreCliente, Producto.NombreProducto, " +
                                 "Producto.Peso, Producto.Dimensiones, Producto.CostoEntrega , Producto.IdProducto " +  
                                 "FROM almacen.Producto " +
                                 "INNER JOIN almacen.Proveedor ON Producto.IdProveedor = Proveedor.IdProveedor " +
                                 "INNER JOIN logistica.DomicilioCliente ON Producto.IdDomicilio = DomicilioCliente.IdDomicilio " + 
                                 "INNER JOIN logistica.Cliente ON DomicilioCliente.IdCliente = Cliente.IdCliente"; 


                SqlCommand scm = new SqlCommand(selectInfo, nuevaConexion);
                SqlDataReader lector = scm.ExecuteReader();

                // Configuración de columnas solo si es necesario
                if (TablaProducto.Columns.Count == 0)
                {
                    TablaProducto.Columns.Add("IdProducto", "ID");
                    TablaProducto.Columns.Add("Proveedor", "Proveedor");
                    TablaProducto.Columns.Add("Domicilio", "Domicilio del Cliente");
                    TablaProducto.Columns.Add("Producto", "Producto");
                    TablaProducto.Columns.Add("Peso", "Peso (Kg)");
                    TablaProducto.Columns.Add("Dimension", "Dimensiones (in)");
                    TablaProducto.Columns.Add("Costo", "Costo de Entrega ($)");


                }

                TablaProducto.Rows.Clear(); // Limpia las filas del DataGridView

                int i = 0;
                while (lector.Read())
                {
                    // Obtiene y formatea los datos de cada columna
                    string IdProducto = lector["IdProducto"].ToString();
                    string nombreProveedor = lector["NombreProveedor"].ToString();
                    string telProveedor = lector["TelefonoProveedor"].ToString();
                    string Calle = lector["Calle"].ToString();
                    string NumeroInterior = lector["NumeroInterior"].ToString();
                    string NumeroExterior = lector["NumeroExterior"].ToString();
                    string NombreCliente = lector["NombreCliente"].ToString();
                    string NombreProducto = lector["NombreProducto"].ToString();
                    string Dimension = lector["Dimensiones"].ToString();
                    string Peso = lector["Peso"].ToString();
                   
                    string Costo = Convert.ToDecimal(lector["CostoEntrega"]).ToString("0.00");


                    // Formatea las cadenas
                    string ProveedorInfo = $"{nombreProveedor}-{telProveedor.Substring(telProveedor.Length - 3)}";
                    string DomicilioInfo = $"{Calle}-{NumeroInterior}-{NumeroExterior} ({NombreCliente})";

                    // Agrega una nueva fila con los datos formateados
                    TablaProducto.Rows.Add(IdProducto, ProveedorInfo, DomicilioInfo,NombreProducto, Peso, Dimension, Costo);

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
            


            string IdProveedor = ((KeyValuePair<string, string>)comboBoxCliente.SelectedItem).Key;
            string IdDomicilio = ((KeyValuePair<string, string>)comboBoxDomicilio.SelectedItem).Key;

            nuevaConexion.Open();

          


              
                    

                        string insertInfo = "INSERT INTO almacen.Producto (IdProveedor, IdDomicilio, NombreProducto, Peso, Dimensiones) VALUES ('" + IdProveedor + "', '" + IdDomicilio + "', '" + textNombreProducto.Text + "', '" + textPeso.Text +
                    "', '" + textDimensiones.Text + "')";

                        SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
                        cm.ExecuteNonQuery();
                    
                
            

            nuevaConexion.Close();

        }

        public void CargaProveedor()
        {

            try
            {
                nuevaConexion.Open();
                String selectInfo = "SELECT IdProveedor, TelefonoProveedor, NombreProveedor FROM almacen.Proveedor ";
                SqlCommand cmd = new SqlCommand(selectInfo, nuevaConexion);
                SqlDataReader lector = cmd.ExecuteReader();

                comboBoxCliente.Items.Clear();  // Limpiar ComboBox 

                while (lector.Read())
                {
                    // Obtener el  cliente y telefono
                    string nombreProveedor = lector["NombreProveedor"].ToString();
                    string telProveedor = lector["TelefonoProveedor"].ToString();


                    string proveedorInfo = $"{nombreProveedor}-{telProveedor.Substring(telProveedor.Length - 3)}";


                    comboBoxCliente.Items.Add(new KeyValuePair<string, string>(lector["IdProveedor"].ToString(), proveedorInfo));
                }

                comboBoxCliente.DisplayMember = "Value"; // Mostrar el nombre en el ComboBox
                comboBoxCliente.ValueMember = "Key"; // El valor será el IdCliente

                lector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los provedores: " + ex.Message);
            }
            finally
            {
                nuevaConexion.Close();
            }

        }

        public void CargaDomicilioCliente()
        {


            try
            {
                nuevaConexion.Open();
                String selectInfo = "SELECT IdDomicilio, Calle, NumeroInterior, NumeroExterior, NombreCliente"+
                    "  FROM logistica.DomicilioCliente INNER JOIN logistica.Cliente ON DomicilioCliente.IdCliente =  Cliente.IdCliente";
                SqlCommand cmd = new SqlCommand(selectInfo, nuevaConexion);
                SqlDataReader lector = cmd.ExecuteReader();

                comboBoxDomicilio.Items.Clear();  // Limpiar ComboBox 

                while (lector.Read())
                {

                   
                    string Calle = lector["Calle"].ToString();
                    string NumeroInterior = lector["NumeroInterior"].ToString();
                    string NumeroExterior = lector["NumeroExterior"].ToString();
                    string NombreCliente = lector["NombreCliente"].ToString();



                    string DomicilioInfo = $"{Calle}-{NumeroInterior}-{NumeroExterior} ({NombreCliente})";


                    comboBoxDomicilio.Items.Add(new KeyValuePair<string, string>(lector["IdDomicilio"].ToString(), DomicilioInfo));
                }

                comboBoxDomicilio.DisplayMember = "Value"; // Mostrar el nombre en el ComboBox
                comboBoxDomicilio.ValueMember = "Key"; // El valor será el IdCliente

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
            try
            {
                // Abrir conexión
                nuevaConexion.Open();

                // Obtener los datos actualizados de los controles
                string IdProveedor = ((KeyValuePair<string, string>)comboBoxCliente.SelectedItem).Key;
                string IdDomicilio = ((KeyValuePair<string, string>)comboBoxDomicilio.SelectedItem).Key;
                string nombreProducto = textNombreProducto.Text;
                string peso = textPeso.Text;
                string dimensiones = textDimensiones.Text;

                // Crear la consulta SQL de actualización
                string updateQuery = "UPDATE almacen.Producto SET " +
                                     "IdProveedor = @IdProveedor, " +
                                     "IdDomicilio = @IdDomicilio, " +
                                     "NombreProducto = @NombreProducto, " +
                                     "Peso = @Peso, " +
                                     "Dimensiones = @Dimensiones " +
                                     "WHERE IdProducto = @IdProducto";

                // Crear el comando SQL y asignar los parámetros
                SqlCommand cmd = new SqlCommand(updateQuery, nuevaConexion);
                cmd.Parameters.AddWithValue("@IdProveedor", IdProveedor);
                cmd.Parameters.AddWithValue("@IdDomicilio", IdDomicilio);
                cmd.Parameters.AddWithValue("@NombreProducto", nombreProducto);
                cmd.Parameters.AddWithValue("@Peso", peso);
                cmd.Parameters.AddWithValue("@Dimensiones", dimensiones);
                cmd.Parameters.AddWithValue("@IdProducto", IdProducto);

                // Ejecutar el comando
                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    
                }
                else
                {
                    MessageBox.Show("No se encontró el producto para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el producto: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión
                nuevaConexion.Close();
            }
        }

        private void RemoverDato()
        {

            nuevaConexion.Open();

            string insertInfo = "DELETE FROM almacen.Producto WHERE IdProducto = '" + IdProducto + "'";

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

        private void TablaProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén la marca seleccionada
                DataGridViewRow filaSeleccionada = TablaProducto.Rows[e.RowIndex];

                // Obtén el valor de una celda específica (por ejemplo, la primera transporte)
                IdProducto = filaSeleccionada.Cells[0].Value.ToString();

                string idProveedorSeleccionado = filaSeleccionada.Cells[2].Value.ToString();

                foreach (KeyValuePair<string, string> item in comboBoxDomicilio.Items)
                {
                    if (item.Value == idProveedorSeleccionado)
                    {
                        comboBoxDomicilio.SelectedItem = item;
                        break;
                    }
                }

                string idTDomicilioSeleccionado = filaSeleccionada.Cells[1].Value.ToString();

                foreach (KeyValuePair<string, string> item in comboBoxCliente.Items)
                {
                    if (item.Value == idTDomicilioSeleccionado)
                    {
                        comboBoxCliente.SelectedItem = item;
                        break;
                    }
                }

                textNombreProducto.Text = filaSeleccionada.Cells[3].Value.ToString();
                textPeso.Text= filaSeleccionada.Cells[4].Value.ToString();
                textDimensiones.Text = filaSeleccionada.Cells[5].Value.ToString();



            }
        }

        private void LimpiarCampos()
        {
           
            comboBoxCliente.SelectedIndex = -1; ;
            comboBoxDomicilio.SelectedIndex = -1;
            textNombreProducto.Text = "";
            textPeso.Text = "";
            textDimensiones.Text = "";
           

        }

        
    }
}


