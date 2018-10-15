using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Campo.v1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmProducto.GetInstancia().ShowDialog();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmProductoCategoria form = new frmProductoCategoria();
            form.ShowDialog();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ftmCategoria form = new ftmCategoria();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmOrdenDeCompra.GetInstancia().ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
