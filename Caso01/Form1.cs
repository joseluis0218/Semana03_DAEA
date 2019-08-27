using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caso01
{
    public partial class Form1 : Form
    {
        ClsDatos cn = new ClsDatos();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Load(cn.ListaClientes());
            dgClientes.DataSource = dataTable;
            dgEmpleados.DataSource = cn.ListarEmpleado();

            //Listando en un ListBox
            listaPaises.DataSource = cn.ListaPais();
            listaPaises.DisplayMember = "NombrePais";
            listaPaises.ValueMember = "NombrePais";

            //Listando en un ListView


            //List<Proveedor> proveedores = cn.ListaProveedor();

            //ListViewItem item = new ListViewItem(proveedores['Proveedor'].ToString());
            //listaProveedores.Items.Clear();

            //listaProveedores.Items = cn.ListaProveedor();
          //List<Proveedor> proveedores = cn.ListaProveedor();
          // foreach(var item in proveedores)
          //  {
          //      listaProveedores.Items.Add(item.CodigoPostal);
          //  }

            //dataTable.Load(cn.ListaPaises());
            //listaPaises.DataSource = dataTable;
        }
    }
}
