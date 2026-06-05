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
    public partial class DomicilioCliente : Form
    {
        SqlConnection nuevaConexion = Conexion.GetConnection();

        string IdCliente = "";
        string IdDomicilio = "";
        string calle = "";
        string colonia = "";
        string codigoPostal = "";
        string numeroExterior = "";
        string numeroInterior = "";
        String Ext = "";
        String Int = "";
        String Col = "";
        String Cal = "";
        String CP = "";



        public DomicilioCliente()
        {
            InitializeComponent();
            ConsultaDatos();
            CargarClientes();

            // Ajustar tamaño de columnas y celdas.
            TablaDomCliente.Columns[0].Width = 80;
            TablaDomCliente.Columns[1].Width = 160;
            TablaDomCliente.Columns[2].Width = 160;
            TablaDomCliente.Columns[3].Width = 70;
            TablaDomCliente.Columns[4].Width = 70;
            TablaDomCliente.Columns[5].Width = 80;

            TablaDomCliente.Columns[6].Width = 70;

            // Ajustar tamaño de columnas y celdas.


        }

        public void CargarClientes()
        {
            try
            {
                nuevaConexion.Open();
                String selectInfo = "SELECT IdCliente, NombreCliente, TelefonoCliente FROM logistica.Cliente ";
                SqlCommand cmd = new SqlCommand(selectInfo, nuevaConexion);
                SqlDataReader lector = cmd.ExecuteReader();

                comboBoxClientes.Items.Clear();  // Limpiar ComboBox 
                while (lector.Read())
                {
                    // Obtener el  cliente y telefono
                    string nombreCliente = lector["NombreCliente"].ToString();
                    string telefonoCliente = lector["TelefonoCliente"].ToString();

                    string clienteYdigitos = $"{nombreCliente}-{telefonoCliente.Substring(telefonoCliente.Length - 3)}";//sub string para obtener los ultimos 3 digitos


                    comboBoxClientes.Items.Add(new KeyValuePair<string, string>(lector["IdCliente"].ToString(), clienteYdigitos));
                }

                comboBoxClientes.DisplayMember = "Value"; // Mostrar el nombre en el ComboBox
                comboBoxClientes.ValueMember = "Key"; // El valor será el IdCliente

                lector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message);
            }
            finally
            {
                nuevaConexion.Close();
            }

        }

        public void ConsultaDatos()
        {

            nuevaConexion.Open();
            TablaDomCliente.DataSource = null;

            string selectInfo = "SELECT * FROM logistica.DomicilioCliente  INNER JOIN logistica.Cliente  ON logistica.DomicilioCliente.IdCliente = logistica.Cliente.IdCliente  ";

            SqlCommand scm = new SqlCommand(selectInfo, nuevaConexion);
            SqlDataReader lector = scm.ExecuteReader();

            // Limpiar las columnas previas
            if (TablaDomCliente.Columns.Count == 0)
            {
                TablaDomCliente.Columns.Add("IdDomicilio", "ID Domicilio");

                TablaDomCliente.Columns.Add("IdCliente", "Cliente");
                TablaDomCliente.Columns.Add("Calle", "Calle");
                TablaDomCliente.Columns.Add("NumeroExt", "Número Exterior");
                TablaDomCliente.Columns.Add("NumeroInt", "Número Interior");
                TablaDomCliente.Columns.Add("Colonia", "Colonia");
                TablaDomCliente.Columns.Add("CodigoPostal", "CP");
            }

            TablaDomCliente.Rows.Clear();

            int i = 0;
            while (lector.Read())
            {
                TablaDomCliente.Rows.Add();
                TablaDomCliente.Rows[i].Cells[0].Value = lector["IdDomicilio"].ToString();
                string nombreCliente = lector["NombreCliente"].ToString();
                string telefonoCliente = lector["TelefonoCliente"].ToString();

                string clienteYdigitos = $"{nombreCliente}-{telefonoCliente.Substring(telefonoCliente.Length - 3)}";//sub string para obtener los ultimos 3 digitos


                TablaDomCliente.Rows[i].Cells[1].Value = clienteYdigitos;
                TablaDomCliente.Rows[i].Cells[2].Value = lector["Calle"].ToString();
                TablaDomCliente.Rows[i].Cells[3].Value = lector["NumeroExterior"].ToString();
                TablaDomCliente.Rows[i].Cells[4].Value = lector["NumeroInterior"].ToString();
                TablaDomCliente.Rows[i].Cells[5].Value = lector["Colonia"].ToString();
                TablaDomCliente.Rows[i].Cells[6].Value = lector["CodigoPostal"].ToString();
                i++;
            }

            lector.Close();


            nuevaConexion.Close();

        }

        public void InsertaDato()
        {
            if (comboBoxClientes.SelectedItem != null)
            {
                var selectedClient = (KeyValuePair<string, string>)comboBoxClientes.SelectedItem;
                IdCliente = selectedClient.Key;  // Obtén el IdCliente del ComboBox

                calle = textCalle_Cliente.Text;
                numeroExterior = textExt.Text; // Usar valores numéricos
                numeroInterior = textInt.Text; // Usar valores numéricos
                colonia = text_coloniaCliente.Text;
                codigoPostal = text_codigoPostal.Text;

                nuevaConexion.Open();

                if (NumeroInteriorExiste(IdCliente, numeroInterior, numeroExterior, calle, colonia, codigoPostal, nuevaConexion))
                {
                    MessageBox.Show("El domicilio ya esta registrado.");


                }
                else
                {

                    string insertInfo = "INSERT INTO logistica.DomicilioCliente(IdCliente, Calle, NumeroExterior, NumeroInterior, Colonia, CodigoPostal)" +
                                            " VALUES (@IdCliente, @Calle, @NumeroExt, @NumeroInt, @Colonia, @CodigoPostal)";

                    SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
                    cm.Parameters.AddWithValue("@IdCliente", IdCliente);
                    cm.Parameters.AddWithValue("@Calle", calle);
                    cm.Parameters.AddWithValue("@NumeroExt", numeroExterior);
                    cm.Parameters.AddWithValue("@NumeroInt", numeroInterior);
                    cm.Parameters.AddWithValue("@Colonia", colonia);
                    cm.Parameters.AddWithValue("@CodigoPostal", codigoPostal);

                    cm.ExecuteNonQuery();

                    LimpiarCampos();


                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cliente.");

            }
            nuevaConexion.Close();
        }

        public bool NumeroInteriorExiste(string idcliente, string numint, string numext, string calle, string colonia, string codigop, SqlConnection conexion)
        {
            string query = "SELECT COUNT(1) FROM logistica.DomicilioCliente WHERE " +
                "IdCliente =@IdCliente AND NumeroInterior = @Numint AND NumeroExterior = @Numext " +
                "AND Colonia = @colonia AND Calle = @calle AND CodigoPostal = @codigop ";

            using (SqlCommand command = new SqlCommand(query, conexion))
            {
                command.Parameters.AddWithValue("@Idcliente", idcliente);
                command.Parameters.AddWithValue("@Numint", numint);
                command.Parameters.AddWithValue("@Numext", numext);
                command.Parameters.AddWithValue("@colonia", colonia);
                command.Parameters.AddWithValue("@calle", calle);
                command.Parameters.AddWithValue("@codigop", codigop);



                try
                {
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Si el resultado es mayor a 0, significa que ya existe
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al verificar el numerointerior: " + ex.Message);
                    return false;
                }
            }
        }
        private void ModificarDato()
        {
            if (comboBoxClientes.SelectedItem != null)
            {
                var selectedClient = (KeyValuePair<string, string>)comboBoxClientes.SelectedItem;
                IdCliente = selectedClient.Key;  // Obtén el IdCliente del ComboBox

                calle = textCalle_Cliente.Text;
                numeroExterior = textExt.Text; // Usar valores numéricos
                numeroInterior = textInt.Text; // Usar valores numéricos
                colonia = text_coloniaCliente.Text;
                codigoPostal = text_codigoPostal.Text;

                nuevaConexion.Open();



                bool modificoInt = numeroInterior.Equals(Int);
                bool modificoExt = numeroExterior.Equals(Ext);
                bool modificoCol = colonia.Equals(Col);
                bool modificoCal = calle.Equals(Cal);
                bool modificoCP = codigoPostal.Equals(CP);

                bool isMod = false;

                if (!modificoInt || !modificoExt || !modificoCol || !modificoCal || !modificoCP)
                    isMod = true;




                if (NumeroInteriorExiste(IdCliente, numeroInterior, numeroExterior, calle, colonia, codigoPostal, nuevaConexion) && isMod)
                {
                    MessageBox.Show("El número interior ya está registrado.");


                }
                else
                {


                    string updateInfo = "UPDATE logistica.DomicilioCliente SET IdCliente = @IdCliente, Calle = @Calle, NumeroExterior = @NumeroExt, " +
                                        "NumeroInterior = @NumeroInt, Colonia = @Colonia, CodigoPostal = @CodigoPostal " +
                                        "WHERE IdDomicilio = @IdDomicilio";

                    SqlCommand cm = new SqlCommand(updateInfo, nuevaConexion);
                    cm.Parameters.AddWithValue("@IdCliente", IdCliente);
                    cm.Parameters.AddWithValue("@Calle", calle);
                    cm.Parameters.AddWithValue("@NumeroExt", numeroExterior);
                    cm.Parameters.AddWithValue("@NumeroInt", numeroInterior);
                    cm.Parameters.AddWithValue("@Colonia", colonia);
                    cm.Parameters.AddWithValue("@CodigoPostal", codigoPostal);
                    cm.Parameters.AddWithValue("@IdDomicilio", IdDomicilio);

                    cm.ExecuteNonQuery();

                    LimpiarCampos();


                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cliente.");
            }
            nuevaConexion.Close();
        }

        private void RemoverDato()
        {
            nuevaConexion.Open();

            string deleteInfo = "DELETE FROM logistica.DomicilioCliente WHERE IdDomicilio = @IdDomicilio";

            SqlCommand cm = new SqlCommand(deleteInfo, nuevaConexion);
            cm.Parameters.AddWithValue("@IdDomicilio", IdDomicilio);

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
        }

        private void LimpiarCampos()
        {
            textCalle_Cliente.Clear();
            textExt.Clear();
            textInt.Clear();
            text_coloniaCliente.Clear();
            text_codigoPostal.Clear();
            comboBoxClientes.SelectedIndex = -1;  // Deseleccionar el cliente
        }

        private void TablaDomCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = TablaDomCliente.Rows[e.RowIndex];

                IdDomicilio = filaSeleccionada.Cells[0].Value.ToString();

                string idClienteSeleccionado = filaSeleccionada.Cells[1].Value.ToString();

                foreach (KeyValuePair<string, string> item in comboBoxClientes.Items)
                {
                    if (item.Value == idClienteSeleccionado)
                    {
                        comboBoxClientes.SelectedItem = item;
                        break;
                    }
                }

                textCalle_Cliente.Text = filaSeleccionada.Cells[2].Value.ToString();
                textExt.Text = filaSeleccionada.Cells[3].Value.ToString();
                textInt.Text = filaSeleccionada.Cells[4].Value.ToString();
                text_coloniaCliente.Text = filaSeleccionada.Cells[5].Value.ToString();
                text_codigoPostal.Text = filaSeleccionada.Cells[6].Value.ToString();

                Cal = filaSeleccionada.Cells[2].Value.ToString();
                Ext = filaSeleccionada.Cells[3].Value.ToString();
                Int = filaSeleccionada.Cells[4].Value.ToString();
                Col = filaSeleccionada.Cells[5].Value.ToString();
                CP = filaSeleccionada.Cells[6].Value.ToString();
            }


        }

        private void DomicilioCliente_Load(object sender, EventArgs e)
        {

        }
    }
}