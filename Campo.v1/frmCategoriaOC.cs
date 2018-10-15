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
    public partial class ftmCategoria : Form
    {
        


        public ftmCategoria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

      /*      bsOC objNewDesc = new bsOC();
            Estado_OC Estado = new Estado_OC();

            Estado.Descricion = "fedecapo";
            Estado.Nombre = "Fede";

            objNewDesc.CrearNuevaCategoriaOC(Estado);

            List<Estado_OC> Lista = new List<Estado_OC>();

            Lista = objNewDesc.MostrarEstadosBynombre("holis");
            dataGridView1.DataSource = Lista;

            dataGridView1.Columns["idestadoOrdenCompra"].Visible = false;


    */

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ftmCategoria_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mostrar();

        }

        private void mostrar() {
            nOrdenCompra objNewDesc = new nOrdenCompra();
            EstadoOrdenCompra Estado = new EstadoOrdenCompra();
            List<EstadoOrdenCompra> Lista = new List<EstadoOrdenCompra>();

            Lista = objNewDesc.MostrarEstados();
            dataListadoCat.DataSource = Lista;

            dataListadoCat.Columns["idestadoOrdenCompra"].Visible = false;
            dataListadoCat.Columns[0].Visible = false;
            lblTotal.Text = "Total de Categorias " + Convert.ToString(dataListadoCat.Rows.Count);

        }

        private void mostrarNombre()
        {
            nOrdenCompra objNewDesc = new nOrdenCompra();
            EstadoOrdenCompra Estado = new EstadoOrdenCompra();
            List<EstadoOrdenCompra> Lista = new List<EstadoOrdenCompra>();

            Lista = objNewDesc.MostrarEstadosBynombre(this.textBuscar.Text);
            dataListadoCat.DataSource = Lista;

            dataListadoCat.Columns["idestadoOrdenCompra"].Visible = false;
            lblTotal.Text = "Total de Categorias " + Convert.ToString(dataListadoCat.Rows.Count);

        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarNombre();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            nOrdenCompra objNewDesc = new nOrdenCompra();
            EstadoOrdenCompra Estado = new EstadoOrdenCompra();

            Estado.Nombre = txtNombre.Text;
            Estado.Descricion = txtDescripcion.Text;
           

            objNewDesc.CrearNuevaCategoriaOC(Estado);
        }

        private void dataListadoCat_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdCategoria.Text = Convert.ToString(this.dataListadoCat.CurrentRow.Cells["idestadoOrdenCompra"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListadoCat.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListadoCat.CurrentRow.Cells["descricion"].Value);
            this.tabControl1.SelectedIndex = 1;

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

        private void dataListadoCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListadoCat.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListadoCat.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string codigo;
            nOrdenCompra Norden = new nOrdenCompra();
            foreach (DataGridViewRow row in dataListadoCat.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {

                    codigo = Convert.ToString(row.Cells[3].Value);
                    MessageBox.Show(codigo);
                    Norden.EliminarPorID(codigo);
                }



            }
            mostrar();
        }
    }
}
