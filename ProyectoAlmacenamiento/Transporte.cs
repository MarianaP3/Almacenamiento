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
    public partial class Transporte : Form
    {
        SqlConnection nuevaConexion = Conexion.GetConnection();


        string IdTransporte = "";
        string transporte = "";
        string marca = "";
        string modelo = "";
        string color = "";
        string placa = "";
        string capacidad = "";
        String placaAnterior = "";


        public Transporte()
        {
            InitializeComponent();
            ConsultaDatos();
            comboBox1.Items.Add("Camión");
            comboBox1.Items.Add("Camioneta");
            comboBox1.Items.Add("Motocicleta");
            comboBox1.Items.Add("Coche");


        }

        private bool EsCapacidadValida(string tipoTransporte, string capacidad)
        {
            int capacidadMaxima = 0;
            bool esValida = false;

            // Validar que la capacidad sea un número
            if (!int.TryParse(capacidad, out int capacidadNum))
            {
                MessageBox.Show("Capacidad debe ser un número.");
                return false; // No es un número válido
            }

            // Verificar el tipo de transporte y el límite de capacidad
            if (tipoTransporte == "Camión")
            {
                capacidadMaxima = 15;
                esValida = capacidadNum <= capacidadMaxima;
            }
            else if (tipoTransporte == "Camioneta")
            {
                capacidadMaxima = 10;
                esValida = capacidadNum <= capacidadMaxima;
            }
            else if (tipoTransporte == "Coche")
            {
                capacidadMaxima = 5;
                esValida = capacidadNum <= capacidadMaxima;
            }
            else if (tipoTransporte == "Motocicleta")
            {
                capacidadMaxima = 2;
                esValida = capacidadNum <= capacidadMaxima;
            }

            if (!esValida)
            {
                MessageBox.Show($"Capacidad máxima para {tipoTransporte} es {capacidadMaxima}.");
            }

            return esValida;
        }

        public void ConsultaDatos()
        {

            nuevaConexion.Open();
            TablaTransporte.DataSource = null;
            String selectInfo = "SELECT * FROM logistica.Transporte";
            SqlCommand scm = new SqlCommand(selectInfo, nuevaConexion);
            SqlDataReader lector = scm.ExecuteReader();

            if (TablaTransporte.Columns.Count == 0)
            {
                TablaTransporte.Columns.Add("IdTransporte", "ID");
                TablaTransporte.Columns.Add("Transporte", "Transporte");
                TablaTransporte.Columns.Add("Marca", "Marca");
                TablaTransporte.Columns.Add("Modelo", "Modelo");
                TablaTransporte.Columns.Add("Color", "Color");
                TablaTransporte.Columns.Add("Placa", "Placa");
                TablaTransporte.Columns.Add("Capacidad", "Capacidad");


            }

            TablaTransporte.Rows.Clear();

            int i = 0;
            while (lector.Read())
            {
                TablaTransporte.Rows.Add();
                TablaTransporte.Rows[i].Cells[0].Value = lector["IdTransporte"].ToString();
                TablaTransporte.Rows[i].Cells[1].Value = lector["Transporte"].ToString();
                TablaTransporte.Rows[i].Cells[2].Value = lector["Marca"].ToString();
                TablaTransporte.Rows[i].Cells[3].Value = lector["Modelo"].ToString();
                TablaTransporte.Rows[i].Cells[4].Value = lector["Color"].ToString();
                TablaTransporte.Rows[i].Cells[5].Value = lector["Placa"].ToString();
                TablaTransporte.Rows[i].Cells[6].Value = lector["Capacidad"].ToString();

                i++;
            }

            lector.Close();
            nuevaConexion.Close();
        }


        public void InsertaDato()
        {
            transporte = comboBox1.Text;
            marca = textMarca.Text;
            modelo = textModelo.Text;
            color = textColor.Text;
            placa = textPlaca.Text;
            capacidad = textCapacidad.Text;

            // Validar la capacidad antes de insertar
            if (!EsCapacidadValida(transporte, capacidad))
            {
                MessageBox.Show("Capacidad no válida para el tipo de transporte.");
                return; // Detener la inserción si la capacidad es incorrecta
            }

            nuevaConexion.Open();

            if (PlacaExiste(placa, nuevaConexion))
            {
                MessageBox.Show("Placa ya registrada.");
            }
            else if (transporte == "Camión" || transporte == "Camioneta" || transporte == "Motocicleta" || transporte == "Coche")
            {
                string insertInfo = "INSERT INTO logistica.Transporte(Transporte, Marca," +
                "Modelo, Color, Placa, Capacidad) VALUES ('" + transporte + "'," +
                 "'" + marca + "','" + modelo + "','" + color + "','" + placa + "','" + capacidad + "')";

                SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
                cm.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("El trasporte es incorrecto.");
            }

            transporte = "";
            marca = "";
            modelo = "";
            color = "";
            placa = "";
            capacidad = "";

            nuevaConexion.Close();
        }

        public bool PlacaExiste(string placa, SqlConnection conexion)
        {
            string query = "SELECT COUNT(1) FROM logistica.Transporte WHERE Placa = @Placa";

            using (SqlCommand command = new SqlCommand(query, conexion))
            {
                command.Parameters.AddWithValue("@Placa", placa);

                try
                {
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Si el resultado es mayor a 0, significa que ya existe
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al verificar la placa: " + ex.Message);
                    return false;
                }
            }
        }

        public void ModificarDato()
        {
            transporte = comboBox1.Text;
            marca = textMarca.Text;
            modelo = textModelo.Text;
            color = textColor.Text;
            placa = textPlaca.Text;
            capacidad = textCapacidad.Text;

            // Validar la capacidad antes de modificar
            if (!EsCapacidadValida(transporte, capacidad))
            {
                MessageBox.Show("Capacidad no válida para el tipo de transporte.");
                return; // Detener la modificación si la capacidad es incorrecta
            }

            nuevaConexion.Open();

            bool modificoPlaca = placaAnterior.Equals(placa);

            if (PlacaExiste(placa, nuevaConexion) && !modificoPlaca)
            {
                MessageBox.Show("Placa ya registrada.");
            }
            else if (transporte == "Camión" || transporte == "Camioneta" || transporte == "Motocicleta" || transporte == "Coche")
            {
                string updateInfo = "UPDATE logistica.Transporte SET Transporte = '" + transporte + "', Marca = '" +
               marca + "', Modelo = '" + modelo + "', Color = '" + color + "', Placa = '" + placa + "', Capacidad = '" + capacidad + "' WHERE IdTransporte = '" + IdTransporte + "'";

                SqlCommand cm = new SqlCommand(updateInfo, nuevaConexion);
                cm.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("El trasporte es incorrecto.");
            }

            transporte = "";
            marca = "";
            modelo = "";
            color = "";
            placa = "";
            capacidad = "";

            nuevaConexion.Close();
        }

        private void RemoverDato()
        {

            nuevaConexion.Open();

            string insertInfo = "DELETE FROM logistica.Transporte WHERE IdTransporte = '" + IdTransporte + "'";

            SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
            cm.ExecuteNonQuery();

            nuevaConexion.Close();


        }


        private void botonClickEliminar_Click(object sender, EventArgs e)
        {
            RemoverDato();
            ConsultaDatos();
            IdTransporte = "";
            comboBox1.Text = "";
            textMarca.Clear();
            textModelo.Clear();
            textColor.Clear();
            textPlaca.Clear();
            textCapacidad.Clear();

        }

        private void botonClickModificar_Click(object sender, EventArgs e)
        {
            ModificarDato();
            ConsultaDatos();
            IdTransporte = "";
            comboBox1.Text = "";
            textMarca.Clear();
            textModelo.Clear();
            textColor.Clear();
            textPlaca.Clear();
            textCapacidad.Clear();
        }

        private void botonClickInsertar_Click(object sender, EventArgs e)
        {
            InsertaDato();
            ConsultaDatos();
            comboBox1.Text = "";
            textMarca.Clear();
            textModelo.Clear();
            textColor.Clear();
            textPlaca.Clear();
            textCapacidad.Clear();
        }

        private void TablaTransporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén la marca seleccionada
                DataGridViewRow filaSeleccionada = TablaTransporte.Rows[e.RowIndex];

                // Obtén el valor de una celda específica (por ejemplo, la primera transporte)
                IdTransporte = filaSeleccionada.Cells[0].Value.ToString();
                comboBox1.Text = filaSeleccionada.Cells[1].Value.ToString();
                textMarca.Text = filaSeleccionada.Cells[2].Value.ToString();
                textModelo.Text = filaSeleccionada.Cells[3].Value.ToString();
                textColor.Text = filaSeleccionada.Cells[4].Value.ToString();
                textPlaca.Text = filaSeleccionada.Cells[5].Value.ToString();
                textCapacidad.Text = filaSeleccionada.Cells[6].Value.ToString();
                placaAnterior = filaSeleccionada.Cells[5].Value.ToString();


            }
        }


    }
}
