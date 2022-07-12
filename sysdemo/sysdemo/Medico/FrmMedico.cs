using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;

namespace sysdemo.Medico
{
    public partial class FrmMedico : Form
    {
        public FrmMedico()
        {
            InitializeComponent();
        }

        private void FrmMedico_Load(object sender, EventArgs e)
        {
            mostrarReg();
        }
        private void mostrarReg()
        {
            CNmedico obj = new CNmedico();
            dataGridView1.DataSource = obj.mostrar();
            dataGridView1.Columns[0].Visible = false;//esconder la columna id
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[1].HeaderText = "Apellidos Médico";
            dataGridView1.Columns[2].Width = 180;
            dataGridView1.Columns[2].HeaderText = "Nombre Médico";
            dataGridView1.Columns[3].HeaderText = "D.N.I";
            dataGridView1.Columns[4].HeaderText = "Celular";
            dataGridView1.Columns[5].Width = 140;
            dataGridView1.Columns[5].HeaderText = "Distrito";
            dataGridView1.Columns[6].Width = 140;
            dataGridView1.Columns[6].HeaderText = "Especialidad";
            dataGridView1.Columns[7].HeaderText = "Colegiatura";
            dataGridView1.Columns[8].Width = 40;
            dataGridView1.Columns[8].HeaderText = "Movil";

        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Frmabcmedico frm = new Frmabcmedico();
            frm.LblOpcion.Text = "Nuevo";
            frm.ShowDialog();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            Frmabcmedico frm = new Frmabcmedico();
            // LblId permitirá almacenar el id del medico al cual se va a modificar sus datos.
            frm.LblId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.LblOpcion.Text = "Editar";
            frm.btngrabar.Text = "Actualizar";
            frm.ShowDialog();
        }

        private void FrmMedico_Activated(object sender, EventArgs e)
        {
            mostrarReg();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            string xid= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            CNmedico obj = new CNmedico();
            obj.EliminaMedico(Convert.ToInt32(xid));
            dataGridView1.DataSource = obj.mostrar();
        }

        private void txtapellidos_TextChanged(object sender, EventArgs e)
        {
            CNmedico obj = new CNmedico();
            dataGridView1.DataSource = obj.MostrarApellido(txtapellidos.Text);
        }
    }
}
