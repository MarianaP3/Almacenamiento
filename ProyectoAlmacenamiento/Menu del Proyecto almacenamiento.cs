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
    public partial class Menu_del_almacenamiento : Form
    {
        public Menu_del_almacenamiento()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Proveedor tablaProveedor = new Proveedor();
            tablaProveedor.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cliente tablaCliente = new Cliente();
            tablaCliente.Show();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anaquel tablaAnaquel = new Anaquel();
            tablaAnaquel.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Transporte tablaTransporte = new Transporte();
            tablaTransporte.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Transportista tablaTransportista = new Transportista();
            tablaTransportista.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DomicilioCliente tablaDomicilioCliente = new DomicilioCliente();
            tablaDomicilioCliente.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Producto tablaProducto = new Producto();
            tablaProducto.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Ruta tablaRuta = new Ruta();
            tablaRuta.Show();
        }

       
        private void button9_Click(object sender, EventArgs e)
        {
            AlmacenamientoProducto tablaAlmacenamientoProducto = new AlmacenamientoProducto();
            tablaAlmacenamientoProducto.Show();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Entrega tablaEntrega = new Entrega();
            tablaEntrega.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DetalleEntrega tablaEntregaDetalles = new DetalleEntrega();
            tablaEntregaDetalles.Show();
        }
    }
}
