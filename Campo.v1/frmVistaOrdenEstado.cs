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
    public partial class frmVistaOrdenEstado : Form
    {
        public frmVistaOrdenEstado()
        {
            InitializeComponent();
        }

        private void LBCategorias_Click(object sender, EventArgs e)
        {

        }

        private void frmVistaOrdenEstado_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void mostrar()
        {
            nOrdenCompra objorden = new nOrdenCompra();
            EstadoOrdenCompra Estado = new EstadoOrdenCompra();
            List<EstadoOrdenCompra> Lista = new List<EstadoOrdenCompra>();

            Lista = objorden.MostrarEstados();
            dataListadoCat.DataSource = Lista;

            dataListadoCat.Columns["idEstadoOrdenCompra"].Visible = false;
            dataListadoCat.Columns[0].Visible = false;
            lblTotal.Text = "Total de Categorias " + Convert.ToString(dataListadoCat.Rows.Count);

        }

        private void dataListadoCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataListadoCat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmOrdenDeCompra form = frmOrdenDeCompra.GetInstancia();
            string id;
            string estado;
            estado = Convert.ToString(this.dataListadoCat.CurrentRow.Cells["Nombre"].Value);
            id = Convert.ToString(this.dataListadoCat.CurrentRow.Cells["idEstadoOrdenCompra"].Value);

            DialogResult boton = MessageBox.Show("Estas seguro de cambiar el estado de la orden de compra a"+estado+"?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (boton == DialogResult.OK)
            {
                form.setCategoria(estado,id);

                this.Hide();
            }
            else //boton cancelar
            { } //regresar al winForm


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
