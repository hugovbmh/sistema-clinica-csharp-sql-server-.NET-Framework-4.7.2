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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            año.Text = Program.general.añoperu;
            int xidrol = Program.general.xidrol;//guardar el idrol del usuario
            CNseguridad obj = new CNseguridad();// obj es el controlador
            DataTable dt = new DataTable();// creando una tabla en memoria
            dt = obj.MostrarData("usp_listaMenu");
            // Controlar los menus de acuerdo al id rol del usuario que accede al sistema
            int k = 0;
            int[] nivel = new int[dt.Rows.Count];
            while (k <= dt.Rows.Count - 1)
            {
                nivel[k] = Convert.ToInt16(dt.Rows[k]["id_rol"].ToString());
                k++;
            }
            // según el nivel se va a desactivar el menu
            if (xidrol < nivel[0]) menu0101.Enabled = false;
            if (xidrol < nivel[1]) menu0102.Enabled = false;
            if (xidrol < nivel[2]) menu0201.Enabled = false;
            if (xidrol < nivel[3]) menu0301.Enabled = false;
            if (xidrol < nivel[4]) menu0302.Enabled = false;
            if (xidrol < nivel[5]) menu0401.Enabled = false;
            if (xidrol < nivel[6]) menu0601.Enabled = false;
            if (xidrol < nivel[7]) menu0602.Enabled = false;
            if (xidrol < nivel[8]) menu0603.Enabled = false;
            if (xidrol < nivel[9]) menu0604.Enabled = false;
        }

        private void menu0601_Click(object sender, EventArgs e)
        {
            Mantenimiento.FrmEspecialidad frm = new Mantenimiento.FrmEspecialidad();
            frm.ShowDialog();
        }

        private void menu0301_Click(object sender, EventArgs e)
        {
            Medico.FrmMedico frm = new Medico.FrmMedico();
            frm.ShowDialog();
        }

        private void menu0501_Click(object sender, EventArgs e)
        {
            Guias.FrmListaGuias frm = new Guias.FrmListaGuias();
            frm.ShowDialog();
        }
    }
}
