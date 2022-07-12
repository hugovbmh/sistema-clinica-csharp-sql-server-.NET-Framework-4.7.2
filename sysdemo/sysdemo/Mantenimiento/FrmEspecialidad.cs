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

namespace sysdemo.Mantenimiento
{
    public partial class FrmEspecialidad : Form
    {
        public FrmEspecialidad()
        {
            InitializeComponent();
        }

        private void FrmEspecialidad_Load(object sender, EventArgs e)
        {
            this.Height = 380;
            CNmantenimiento obj = new CNmantenimiento();
            dataGridView1.DataSource = obj.mostrar();//llene el datagridview con todas las especialidades
            formato();//formato para el control datagridview
        }
        private void formato()
        {
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[1].HeaderText = "Especialidad";

        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            lblid.Text = "";
            txtdescripcion.Clear();
            txtdescripcion.Focus();
            btngrabar.Text = "Grabar";
            this.Height = 550;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            btngrabar.Text = "Actualizar";
            lblid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtdescripcion.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtdescripcion.Focus();
            this.Height = 550;
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            CNmantenimiento obj = new CNmantenimiento();
            if (txtdescripcion.Text == "")
            {
                MessageBox.Show("Favor de ingresar la descripción", "Aviso");
                txtdescripcion.Focus();
            }
            else
            {
                if (btngrabar.Text == "Grabar") obj.IngEspecialidad(txtdescripcion.Text);//nueva especialidad
                else obj.ModEspecialidad(Convert.ToInt32(lblid.Text), txtdescripcion.Text);//modificar datos
            }
            dataGridView1.DataSource = obj.mostrar();
            this.Height = 380;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Height = 380;
        }

        private void txtespecialidad_TextChanged(object sender, EventArgs e)
        {
            CNmantenimiento obj = new CNmantenimiento();
            dataGridView1.DataSource = obj.BusEsp(txtespecialidad.Text);
        }
    }
}
