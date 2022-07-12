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
namespace sysdemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            CNseguridad obj = new CNseguridad();// creando un objeto para trabajar con el controlador
            DataTable dt = obj.login(txtusuario.Text, obj.Encriptar(txtcontraseña.Text));
            if (dt.Rows.Count == 1)//si existe el usuario
            {
                Program.general.xusuario = txtusuario.Text;
                Program.general.xrol = dt.Rows[0]["nom_rol"].ToString();
                Program.general.xidrol =Convert.ToInt16(dt.Rows[0]["id_rol"].ToString());
                Program.general.xempleado = dt.Rows[0]["nom_emp"].ToString()+ " " + dt.Rows[0]["ape_emp"].ToString();
                FrmMenu frm = new FrmMenu();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error verificar el usuario o clave ingresada!!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
