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
    public partial class frmOrdenDeCompra : Form
    {

        private static frmOrdenDeCompra _Instancia;
        int flagNuevaOC;
        public static frmOrdenDeCompra GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmOrdenDeCompra();
            }
            return _Instancia;
        }

        public frmOrdenDeCompra()
        {
            InitializeComponent();
        }

        private void OrdenDeCompra_Load(object sender, EventArgs e)
        {
            mostrar();
        }
        public void setCategoria(string nombre,string estado)
        {


            nOrdenCompra norden = new nOrdenCompra();
            norden.cambiarEstadoOC(Convert.ToString(desc_codigo.Text), estado);

        }



        void mostrar() {


            List<OrdenCompra> Lista = new List<OrdenCompra>();
            nOrdenCompra nOrden = new nOrdenCompra();
            dataListadoCat.Columns[0].Visible = false;

            Lista = nOrden.ShowOrdenCompra();



            dataListadoCat.DataSource = Lista;




        }

        private void dataListadoCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
     
        }

        private void dataListadoCat_DoubleClick(object sender, EventArgs e)
        {


            string idOrden = Convert.ToString(this.dataListadoCat.CurrentRow.Cells["id_orden_compra"].Value);
            nOrdenCompra InstNeg = new nOrdenCompra();
            OrdenCompra InstOrden = new OrdenCompra();

            InstOrden = InstNeg.ShowOrdenCompraByID(idOrden);


            this.desc_nombre.Text = InstOrden.Nombre;
            this.desc_desc.Text = InstOrden.Descripcion;
            this.desc_estado.Text = InstOrden.EstadoOrden.Nombre;
            this.desc_codigo.Text = Convert.ToString(InstOrden.Id_Orden_Compra);
            this.desc_fecha.Text = InstOrden.Fecha.ToString();

            this.desc_nombre.Enabled = false;
            this.desc_desc.Enabled = false;
            this.desc_estado.Enabled = false;
            this.desc_codigo.Enabled = false;
            this.desc_fecha.Enabled = false;

            this.tabControl1.SelectedIndex = 2;


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataListadoCat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                var ordenCompra = (OrdenCompra)(this.dataListadoCat.Rows[e.RowIndex].DataBoundItem);
                if (ordenCompra != null && ordenCompra.EstadoOrden != null)
                    e.Value = string.Format("{0}", ordenCompra.EstadoOrden.Nombre);


            }
        }

        private void GridDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void MostrarDetalles(string id,int source) {

            List<OrdenCompraDetalle> Lista = new List<OrdenCompraDetalle>();
            nOrdenCompra nOrden = new nOrdenCompra();

            Lista = nOrden.ShowOrdenCompraDetalleByIdOC(id);


            if (source == 1)
            {
                ed_detallesOc.DataSource = Lista;
            }
            else {

                desc_detalles.DataSource = Lista;
            }



        }

        private void txtIdOrden_TextChanged(object sender, EventArgs e)
        {
            MostrarDetalles(ed_IdOrden.Text,1);
        }

        private void GridDetalles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          
        }

        private void detallesOc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmVistaOrdenEstado form = new frmVistaOrdenEstado();
            form.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void desc_codigo_TextChanged(object sender, EventArgs e)
        {
            MostrarDetalles(desc_codigo.Text,2);

        }

        private void desc_detalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string idOrden = desc_codigo.Text;//Convert.ToString(this.desc_detalles.CurrentRow.Cells["id_orden_compra"].Value);

            nOrdenCompra InstNeg = new nOrdenCompra();
            OrdenCompra InstOrden = new OrdenCompra();

            InstOrden = InstNeg.ShowOrdenCompraByID(idOrden);


            this.ed_Nombre.Text = InstOrden.Nombre;
            this.ed_Descp.Text = InstOrden.Descripcion;
            this.ed_estado.Text = InstOrden.EstadoOrden.Nombre;
            this.ed_IdOrden.Text = Convert.ToString(InstOrden.Id_Orden_Compra);
            this.ed_date.Text = InstOrden.Fecha.ToString();
            this.tabControl1.SelectedIndex = 1;
        }

        private void desc_detalles_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            nOrdenCompra norden = new nOrdenCompra();
            norden.cambiarEstadoOC(Convert.ToString(desc_codigo.Text),"1");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            nOrdenCompra norden = new nOrdenCompra();
            norden.cambiarEstadoOC(Convert.ToString(desc_codigo.Text), "2");

        }

        private void setProducto()
        {




        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmVistaOrdenEstado form = new frmVistaOrdenEstado();
            form.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            this.tabControl1.SelectedIndex = 1;
            flagNuevaOC = 1;
            flagChecker();
        }

        private void flagChecker() {
            if (flagNuevaOC == 1) {
                ed_date.Enabled = false;
                ed_IdOrden.Enabled = false;
                ed_estado.Enabled = false;
                ed_estado.Text = "En espera";
                ed_date.Text = DateTime.Now.ToString("M/d/yyyy");


            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmVistaProducto form = new frmVistaProducto();
            form.ShowDialog();
        }
    }
}
