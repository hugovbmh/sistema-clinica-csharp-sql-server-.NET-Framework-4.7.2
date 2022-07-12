using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sysdemo.Guias
{
    public partial class FrmListaGuias : Form
    {
        public FrmListaGuias()
        {
            InitializeComponent();
        }

        private void btnprocesar_Click(object sender, EventArgs e)
        {
            listarGuia();
        }
        private void listarGuia()
        {
            Capa_Negocio.CNguia obj = new Capa_Negocio.CNguia();
            DataTable dt = new DataTable();
            dt = obj.ListaGuiaFecha(Dtpdesde.Value.ToString(), dtphasta.Value.ToString());
            dataGridView1.DataSource = dt;
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            FrmGuiaIngreso frm = new FrmGuiaIngreso();
            frm.ShowDialog();
        }
    }
}
