using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Buisness;

namespace Campo.v1
{
    public partial class frmVistaCategoriaArticulo : Form
    {
        public frmVistaCategoriaArticulo()
        {
            InitializeComponent();
        }

        private void dataListadoCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataListadoCat_DoubleClick(object sender, EventArgs e)
        {
         
            frmProducto form = frmProducto.GetInstancia();
           
            int id;
            string nombrecat;

            id = Convert.ToInt32(this.dataListadoCat.CurrentRow.Cells["IdProductoCategoria"].Value);
            nombrecat = Convert.ToString(this.dataListadoCat.CurrentRow.Cells["Nombre"].Value);

            form.setCategoria(id, nombrecat);
                this.Hide();

        }

        private void frmVistaCategoriaArticulo_Load(object sender, EventArgs e)
        {
            mostrar();
        }
        private void mostrar()
        {
            nProducto objNewDesc = new nProducto();
            Producto_Categoria Estado = new Producto_Categoria();
            List<Producto_Categoria> Lista = new List<Producto_Categoria>();

            Lista = objNewDesc.MostrarCategoriasProducto();
            dataListadoCat.DataSource = Lista;

            dataListadoCat.Columns["IdProductoCategoria"].Visible = false;
            dataListadoCat.Columns[0].Visible = false;
            lblTotal.Text = "Total de Categorias " + Convert.ToString(dataListadoCat.Rows.Count);

        }
    }
}
