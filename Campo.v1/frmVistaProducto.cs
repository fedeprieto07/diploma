using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buisness;
using Entidades;

namespace Campo.v1
{
    public partial class frmVistaProducto : Form
    {
        public frmVistaProducto()
        {
            InitializeComponent();
        }

        private void dataListadoCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmVistaProducto_Load(object sender, EventArgs e)
        {
            nProducto objNewDesc = new nProducto();
            List<Producto> Lista = new List<Producto>();

            Lista = objNewDesc.MostrarProductos();
            dataListadoProd.DataSource = Lista;

           // dataListadoProd.Columns["IdProductoCategoria"].Visible = false;
      //      dataListadoProd.Columns[0].Visible = false;
           // lblTotal.Text = "Total de Categorias " + Convert.ToString(dataListadoProd.Rows.Count);

        }

        
    }
}
