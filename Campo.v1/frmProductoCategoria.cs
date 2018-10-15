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
    public partial class frmProductoCategoria : Form
    {
        private void mostrarPorNombre()
        {
            nProducto Prod = new nProducto();
            List<Producto_Categoria> Lista = new List<Producto_Categoria>();
            Lista = Prod.MostrarCategoriasProductoBynombre(textBuscar.Text);

            dataListadoCat.DataSource = Lista;


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

        public frmProductoCategoria()
        {
            InitializeComponent();
        }

        private void frmProductoCategoria_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataListadoCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListadoCat.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListadoCat.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void lblTotal_Click(object sender, EventArgs e)
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            nProducto npro = new nProducto();
            string codigo;
            foreach (DataGridViewRow row in dataListadoCat.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {

                    codigo = Convert.ToString(row.Cells[1].Value);
                    MessageBox.Show(codigo);
                    npro.EliminarCategoriaPorID(codigo);
                }



            }
            mostrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarPorNombre();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void txtIdCategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void LBCategorias_Click(object sender, EventArgs e)
        {

        }

        private void dataListadoCat_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdCategoria.Text = Convert.ToString(this.dataListadoCat.CurrentRow.Cells["idproductocategoria"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListadoCat.CurrentRow.Cells["nombre"].Value);
            this.tabControl1.SelectedIndex = 1;
        }
    }
}
