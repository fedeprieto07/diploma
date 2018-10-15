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
    public partial class frmProducto : Form
    {
        private static frmProducto _Instancia;

        public static frmProducto GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmProducto();
            }
            return _Instancia;
        }

        public void setCategoria(int id_cat, string nombre) {

            this.txtIdCat.Text = id_cat.ToString();
            this.txtNombreCat.Text = nombre;
            
        }

        public frmProducto()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            mostrarProductos();
        }


        private void mostrarProductos() {
            List<Producto> Lista = new List<Producto>();
            nProducto nProducto = new nProducto();
            dataListadoCat.Columns[0].Visible = false;

            Lista = nProducto.MostrarProductos();

           

            dataListadoCat.DataSource = Lista;





        }

        private void dataListadoCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListadoCat.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListadoCat.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            nProducto BuisnesProd = new nProducto();

            Producto InstProducto = new Producto();
            Producto_Categoria InstCatProd = new Producto_Categoria();

            InstProducto.Categoria = InstCatProd;

            InstProducto.Nombre = txtNombre.Text;
            InstProducto.Descripcion = txtDescripcino.Text;
            InstProducto.Costo = Convert.ToDouble( txtPrecio.Text);
            InstProducto.Stock = Convert.ToInt32( txtStock.Text);
            InstProducto.Categoria.Nombre = txtNombreCat.Text;
            InstProducto.Categoria.IdProductoCategoria = Convert.ToInt32(txtIdCat.Text);
           
            BuisnesProd.CrearNuevoProducto(InstProducto);

        }

        private void dataListadoCat_DoubleClick(object sender, EventArgs e)
        {

            string idProd = Convert.ToString(this.dataListadoCat.CurrentRow.Cells["Id_Producto"].Value);
            nProducto InstNeg = new nProducto();
            Producto InstPro = new Producto();

            InstPro = InstNeg.BuscarProductoById(idProd);


            this.txtNombre.Text = InstPro.Nombre;
            this.txtDescripcino.Text =InstPro.Descripcion;
            this.txtNombreCat.Text = InstPro.Categoria.Nombre;
            this.txtStock.Text = Convert.ToString(InstPro.Stock);
            this.txtPrecio.Text =Convert.ToString(InstPro.Costo);
            this.txtIdCat.Text =Convert.ToString( InstPro.Categoria.IdProductoCategoria);
            this.txtIdProducto.Text = Convert.ToString(InstPro.Id_Producto);

            this.tabControl1.SelectedIndex = 1;

        }

        private void dataListadoCat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //I Suppose you want to show full name in column at index 3
            if (e.RowIndex >= 0 && e.ColumnIndex == 6)
            {
                var producto = (Producto)(this.dataListadoCat.Rows[e.RowIndex].DataBoundItem);
                if (producto != null && producto.Categoria != null)
                    e.Value = string.Format("{0}", producto.Categoria.Nombre);
                

            }




        }

        private void BtnBuscarCat_Click(object sender, EventArgs e)
        {
            frmVistaCategoriaArticulo form = new frmVistaCategoriaArticulo();
            form.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtidcategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListadoCat.Columns[0].Visible = true;


            }

            else
            {

                this.dataListadoCat.Columns[0].Visible = false;


            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            nProducto npro = new nProducto();
            string codigo;
            foreach (DataGridViewRow row in dataListadoCat.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {

                    codigo = Convert.ToString(row.Cells[5].Value);
                    MessageBox.Show(codigo);
                    npro.EliminarProductoPorID(codigo);
                }



            }
            mostrarProductos();
            chkEliminar.Checked = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mostrarProductos();

        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            nProducto InstanciaProd = new nProducto();
            List<Producto> Lista = new List<Producto>();
            Lista = InstanciaProd.BuscarProductoByNombre(textBuscar.Text);

            dataListadoCat.DataSource = Lista;

        }
    }
}
