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
    public partial class Frmabcmedico : Form
    {
        public Frmabcmedico()
        {
            InitializeComponent();
        }

        private void Frmabcmedico_Load(object sender, EventArgs e)
        {
            if (LblOpcion.Text == "Editar")
            {
                CNmedico obj = new CNmedico();// creando obj para usar funciones del controlador(capa_negocio)
                DataTable dt = new DataTable();
                dt = obj.BusMedicoPorID(Convert.ToInt32(LblId.Text));
                txtnombre.Text = dt.Rows[0]["nom_med"].ToString();
                txtapellidos.Text = dt.Rows[0]["ape_med"].ToString();
                txtdni.Text= dt.Rows[0]["dni_med"].ToString();
                
                string xdis= dt.Rows[0]["nom_dis"].ToString();
                cboDistrito1.mostrarDis(xdis);

                string xesp = dt.Rows[0]["nom_esp"].ToString();
                cboEspecialidad1.mostrarEsp(xesp);

                txtcolegiatura.Text= dt.Rows[0]["nro_col"].ToString();
                txtmovil.Text = dt.Rows[0]["cel_med"].ToString();
            }
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            if (LblOpcion.Text == "Nuevo")
            {
                try
                {
                    CNmedico obj = new CNmedico();
                    string rp = obj.ingMedico(txtnombre.Text, txtapellidos.Text, txtdni.Text,
                        Convert.ToInt32(cboDistrito1.xid), Convert.ToInt32(cboEspecialidad1.xid),
                        txtcolegiatura.Text.ToString(), txtmovil.Text);
                    this.Close();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else//Edición
            {
                CNmedico obj = new CNmedico();
                string rp = obj.ModMedico(Convert.ToInt32(LblId.Text), txtnombre.Text, txtapellidos.Text, txtdni.Text,
                    Convert.ToInt32(cboDistrito1.xid), Convert.ToInt32(cboEspecialidad1.xid),
                    txtcolegiatura.Text.ToString(), txtmovil.Text);
                this.Close();
            }
        }
    }
}
