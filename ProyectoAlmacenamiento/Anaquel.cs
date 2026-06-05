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
    public partial class Anaquel : Form
    {
        SqlConnection nuevaConexion = Conexion.GetConnection();


        string IdAnaquel = "";
        string columna = "";
        string fila = "";
        string nivel = "";
        string capacidad = "";
        String filaanterior = "";
        String nivelanterior = "";
        String columnaanterior = "";

        public Anaquel()
        {
            InitializeComponent();
            ConsultaDatos();
        }


        public void ConsultaDatos()
        {
            nuevaConexion.Open();
            TablaAnaquel.DataSource = null;
            String selectInfo = "SELECT * FROM almacen.Anaquel";
            SqlCommand scm = new SqlCommand(selectInfo, nuevaConexion);
            SqlDataReader lector = scm.ExecuteReader();

            if (TablaAnaquel.Columns.Count == 0)
            {
                TablaAnaquel.Columns.Add("IdAnaquel", "ID");
                TablaAnaquel.Columns.Add("Nivel", "Nivel");
                TablaAnaquel.Columns.Add("Fila", "Fila");
                TablaAnaquel.Columns.Add("Columna", "Columna");
                TablaAnaquel.Columns.Add("Capacidad", "Capacidad");

            }

            TablaAnaquel.Rows.Clear();

            int i = 0;
            while (lector.Read())
            {
                TablaAnaquel.Rows.Add();
                TablaAnaquel.Rows[i].Cells[0].Value = lector["IdAnaquel"].ToString();
                TablaAnaquel.Rows[i].Cells[1].Value = lector["Nivel"].ToString();
                TablaAnaquel.Rows[i].Cells[2].Value = lector["Fila"].ToString();
                TablaAnaquel.Rows[i].Cells[3].Value = lector["Columna"].ToString();
                TablaAnaquel.Rows[i].Cells[4].Value = lector["Capacidad"].ToString();

                i++;
            }

            lector.Close();
            nuevaConexion.Close();
        }



        public void InsertaDato()
        {

            columna = textColumna.Text;
            fila = textFila.Text;
            nivel = textNivel.Text;
            capacidad = textCapacidad.Text;

            nuevaConexion.Open();

            if (LugarExiste(columna, fila, nivel, nuevaConexion))
            {
                MessageBox.Show("El lugar esta ocupado.");
            }
            else if (double.TryParse(fila, out _) && double.TryParse(nivel, out _) && double.TryParse(columna, out _))
            {


                string insertInfo = "INSERT INTO almacen.Anaquel(Columna, " +
                "Fila, Nivel, Capacidad) VALUES ('" + columna + "'," +
                 "'" + fila + "','" + nivel + "','" + capacidad + "')";

                SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
                cm.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Los campos fila, columna y nivel deben ser numéricos.");
            }


            columna = "";
            fila = "";
            nivel = "";
            capacidad = "";


            nuevaConexion.Close();
        }

        public bool LugarExiste(string columna, string fila, string nivel, SqlConnection conexion)
        {
            string query = "SELECT COUNT(1) FROM almacen.Anaquel WHERE Columna = @columna AND Fila = @fila AND Nivel = @nivel";

            using (SqlCommand command = new SqlCommand(query, conexion))
            {
                command.Parameters.AddWithValue("@columna", columna);
                command.Parameters.AddWithValue("@fila", fila);
                command.Parameters.AddWithValue("@nivel", nivel);

                try
                {
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Si el resultado es mayor a 0, significa que ya existe
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al verificar el campos del lugar: " + ex.Message);
                    return false;
                }
            }
        }

        private void ModificarDato()
        {
            columna = textColumna.Text;
            fila = textFila.Text;
            nivel = textNivel.Text;
            capacidad = textCapacidad.Text;


            nuevaConexion.Open();


            // que cheque que se modificó

            bool modificoNivel = nivelanterior.Equals(nivel);
            bool modificoColumna = columnaanterior.Equals(columna);
            bool modificoFila = filaanterior.Equals(fila);


            if (LugarExiste(columna, fila, nivel, nuevaConexion) && !modificoNivel
                || LugarExiste(columna, fila, nivel, nuevaConexion) && !modificoColumna
                || LugarExiste(columna, fila, nivel, nuevaConexion) && !modificoFila)
            {
                MessageBox.Show("El lugar esta ocupado.");
            }
            else if (double.TryParse(fila, out _) && double.TryParse(nivel, out _) && double.TryParse(columna, out _))
            {
                string insertInfo = "UPDATE almacen.Anaquel SET Columna = '" + columna + "', Fila = '" +
                       fila + "', Nivel = '" + nivel + "', Capacidad = '" + capacidad + "' WHERE IdAnaquel = '" + IdAnaquel + "'";

                SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
                cm.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Los campos fila, columna y nivel deben ser numéricos.");
            }

            columna = "";
            fila = "";
            nivel = "";
            capacidad = "";

            nuevaConexion.Close();

        }

        private void RemoverDato()
        {

            nuevaConexion.Open();

            string insertInfo = "DELETE FROM almacen.Anaquel WHERE IdAnaquel = '" + IdAnaquel + "'";

            SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
            cm.ExecuteNonQuery();

            nuevaConexion.Close();


        }


        private void botonClickEliminar_Click(object sender, EventArgs e)
        {
            RemoverDato();
            ConsultaDatos();
            IdAnaquel = "";
            textCapacidad.Clear();
            textColumna.Clear();
            textFila.Clear();
            textNivel.Clear();
        }

        private void botonClickModificar_Click(object sender, EventArgs e)
        {
            ModificarDato();
            ConsultaDatos();
            IdAnaquel = "";
            textCapacidad.Clear();
            textColumna.Clear();
            textFila.Clear();
            textNivel.Clear();
        }

        private void botonClickInsertar_Click(object sender, EventArgs e)
        {
            InsertaDato();
            ConsultaDatos();
            textCapacidad.Clear();
            textColumna.Clear();
            textFila.Clear();
            textNivel.Clear();
        }

        private void TablaAnaquel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén la marca seleccionada
                DataGridViewRow filaSeleccionada = TablaAnaquel.Rows[e.RowIndex];

                // Obtén el valor de una celda específica (por ejemplo, la primera transporte)
                IdAnaquel = filaSeleccionada.Cells[0].Value.ToString();
                textColumna.Text = filaSeleccionada.Cells[3].Value.ToString();
                textFila.Text = filaSeleccionada.Cells[2].Value.ToString();
                textNivel.Text = filaSeleccionada.Cells[1].Value.ToString();
                textCapacidad.Text = filaSeleccionada.Cells[4].Value.ToString();
                columnaanterior = filaSeleccionada.Cells[3].Value.ToString();
                filaanterior = filaSeleccionada.Cells[2].Value.ToString();
                nivelanterior = filaSeleccionada.Cells[1].Value.ToString();

            }
        }
    }
}


