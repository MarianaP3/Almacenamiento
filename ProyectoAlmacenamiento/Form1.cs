using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace ProyectoAlmacenamiento
{

    public partial class Proveedor : Form
    {
        SqlConnection nuevaConexion = new SqlConnection("Server = MARIANAPC\\SQLEXPRESS; " +
            "DATABASE = Almacenamiento; integrated security=true");
        string IdProveedor = "";
        string nombre_proveedor = "";
        string telefono_proveedor = "";
        string correo_proveedor = "";
        string domicilio_fiscal_proveedor = "";
        public Proveedor()
        {
            InitializeComponent();
            ConsultaDatos();
        }

        public void ConsultaDatos()
        {
            nuevaConexion.Open();
            TablaProveedor.DataSource = null;
            String selectInfo = "SELECT * FROM almacen.proveedor";
            SqlCommand scm = new SqlCommand(selectInfo, nuevaConexion);
            SqlDataReader lector = scm.ExecuteReader();

            if (TablaProveedor.Columns.Count == 0)
            {
                TablaProveedor.Columns.Add("IdProveedor", "ID");
                TablaProveedor.Columns.Add("Nombre_proveedor", "Nombre");
                TablaProveedor.Columns.Add("Telefono_proveedor", "Teléfono");
                TablaProveedor.Columns.Add("Correo_proveedor", "Correo");
                TablaProveedor.Columns.Add("Domicilio_fiscal_proveedor", "Domicilio");
            }

            TablaProveedor.Rows.Clear();

            int i = 0;
            while (lector.Read())
            {
                TablaProveedor.Rows.Add();
                TablaProveedor.Rows[i].Cells[0].Value = lector["IdProveedor"].ToString();
                TablaProveedor.Rows[i].Cells[1].Value = lector["NombreProveedor"].ToString();
                TablaProveedor.Rows[i].Cells[2].Value = lector["TelefonoProveedor"].ToString();
                TablaProveedor.Rows[i].Cells[3].Value = lector["CorreoProveedor"].ToString();
                TablaProveedor.Rows[i].Cells[4].Value = lector["DomicilioFiscal"].ToString();
                i++;
            }

            lector.Close();
            nuevaConexion.Close();
        }

        public void InsertaDato()
        {
            nombre_proveedor = textNombre_Proveedor.Text;
            telefono_proveedor = textTelefono_Proveedor.Text;
            correo_proveedor = textCorreo_Proveedor.Text;
            domicilio_fiscal_proveedor = textDomicilio_Proveedor.Text;


            nuevaConexion.Open();

            string insertInfo = "INSERT INTO almacen.Proveedor(NombreProveedor, " +
                "TelefonoProveedor, CorreoProveedor, DomicilioFiscal) VALUES ('" + nombre_proveedor + "'," +
         "'" + telefono_proveedor + "','" + correo_proveedor + "' , '" + domicilio_fiscal_proveedor + "' )";

            SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
            cm.ExecuteNonQuery();

            nombre_proveedor = "";
            telefono_proveedor = "";
            correo_proveedor = "";
            domicilio_fiscal_proveedor = "";

            nuevaConexion.Close();
        }

        private void ModificarDato()
        {
            nombre_proveedor = textNombre_Proveedor.Text;
            telefono_proveedor = textTelefono_Proveedor.Text;
            correo_proveedor = textCorreo_Proveedor.Text;
            domicilio_fiscal_proveedor = textDomicilio_Proveedor.Text;

            nuevaConexion.Open();

            string insertInfo = "UPDATE almacen.Proveedor SET NombreProveedor = '" + nombre_proveedor + "', TelefonoProveedor = '" +
                 telefono_proveedor + "', CorreoProveedor = '" + correo_proveedor + "', DomicilioFiscal = '" + domicilio_fiscal_proveedor + "' WHERE IdProveedor = '" + IdProveedor + "'";

            SqlCommand cm = new SqlCommand(insertInfo, nuevaConexion);
            cm.ExecuteNonQuery();

            nuevaConexion.Close();


        }

        private void RemoverDato()
        {
           
            nuevaConexion.Open();

            string insertInfo = "DELETE FROM almacen.Proveedor WHERE IdProveedor = '" + IdProveedor + "'";

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
            IdProveedor = "";
            textNombre_Proveedor.Clear();
            textTelefono_Proveedor.Clear();
            textCorreo_Proveedor.Clear();
            textDomicilio_Proveedor.Clear();
        }

        private void botonClickModificar_Click(object sender, EventArgs e)
        {
            ModificarDato();
            ConsultaDatos();
            IdProveedor = "";
            textNombre_Proveedor.Clear();
            textTelefono_Proveedor.Clear();
            textCorreo_Proveedor.Clear();
            textDomicilio_Proveedor.Clear();
        }

        private void botonClickInsertar_Click(object sender, EventArgs e)
        {
            InsertaDato();
            ConsultaDatos();
            textNombre_Proveedor.Clear();
            textTelefono_Proveedor.Clear();
            textCorreo_Proveedor.Clear();
            textDomicilio_Proveedor.Clear();
        }

        private void TablaProveedor_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén la fila seleccionada
                DataGridViewRow filaSeleccionada = TablaProveedor.Rows[e.RowIndex];

                // Obtén el valor de una celda específica (por ejemplo, la primera columna)
                IdProveedor = filaSeleccionada.Cells[0].Value.ToString();
                textNombre_Proveedor.Text = filaSeleccionada.Cells[1].Value.ToString();
                textTelefono_Proveedor.Text = filaSeleccionada.Cells[2].Value.ToString();
                textCorreo_Proveedor.Text = filaSeleccionada.Cells[3].Value.ToString();
                textDomicilio_Proveedor.Text = filaSeleccionada.Cells[4].Value.ToString();

            }
        }
    }
}
