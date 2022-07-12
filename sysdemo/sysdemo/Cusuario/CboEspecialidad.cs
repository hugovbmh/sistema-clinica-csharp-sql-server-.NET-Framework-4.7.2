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
    public partial class CboEspecialidad : UserControl
    {
        public CboEspecialidad()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("server=HUGOMH\\SQLEXPRESS;database=SysMedic;integrated security=true");
        public string xid;//almacenará el id de la especialidad seleccionada
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            xid = comboBox1.SelectedValue.ToString();
        }

        private void CboEspecialidad_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("usp_ListaEspecialidad", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);//llenar el dt con el resultado del procedimiento almacenado
            comboBox1.DataSource = dt;//llenando el combobox con todas las especialidades
            comboBox1.DisplayMember = dt.Columns[1].ToString();//nombre de la especialidad
            comboBox1.ValueMember = dt.Columns[0].ToString();//id de la especialidad
            xid = comboBox1.SelectedValue.ToString();
        }
        public void mostrarEsp(string xespecialidad)
        {
            comboBox1.Text = xespecialidad;
        }
    }
}
