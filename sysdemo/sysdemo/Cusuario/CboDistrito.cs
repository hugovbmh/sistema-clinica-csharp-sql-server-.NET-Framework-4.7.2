using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sysdemo.Cusuario
{
    public partial class CboDistrito : UserControl
    {
        public CboDistrito()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("server=HUGOMH\\SQLEXPRESS;database=SysMedic;integrated security=true");
        public string xid;//almacenará el id del distrito seleccionado
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            xid = comboBox1.SelectedValue.ToString();
        }

        private void CboDistrito_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("usp_listaDistrito", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "nom_dis";
            comboBox1.ValueMember = "id_dis";
            xid = comboBox1.SelectedValue.ToString();
        }
        public void mostrarDis(string xdistrito)
        {
            comboBox1.Text = xdistrito;
        }
    }
}
