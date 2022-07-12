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
    public partial class FrmGuiaIngreso : Form
    {
        public FrmGuiaIngreso()
        {
            InitializeComponent();
        }

        private void FrmGuiaIngreso_Load(object sender, EventArgs e)
        {
            Capa_Negocio.CNguia obj = new Capa_Negocio.CNguia();
            DataTable dt = new DataTable();//recibe los resgistros
            ClsSoftware obj_llenar = new ClsSoftware();
            // Llenar tipo
            dt = obj.Mostrardata("usp_ListaTipDoc");
            obj_llenar.llenar_cbo(cbotipo, dt);//llenar el combobox tipo
            cbotipo.SelectedValue = "6";// el 6to tipo de documento en la tabla tip_doc es guia de ingreso
            cbotipo.Enabled = false;
            // Llenar Combobox Proveedor
            dt = obj.Mostrardata("usp_listaprov");
            obj_llenar.llenar_cbo(cboproveedor, dt);
            // Llenar Combobox Productos
            dt = obj.Mostrardata("usp_Listapro");
            obj_llenar.llenar_cbo(cboproducto, dt);
            // Llenar Combobox Empleados
            dt = obj.Mostrardata("usp_ListaEmpleado");
            obj_llenar.llenar_cbo(cboempleado, dt);
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            ListViewItem lv;
            lv = new ListViewItem(cboproducto.SelectedValue.ToString());
            lv.SubItems.Add(cboproducto.Text);
            lv.SubItems.Add(txtcantidad.Text);
            lvdetalle.Items.Add(lv);
        }

        private void btnquitar_Click(object sender, EventArgs e)
        {
            for(int i = 0; i <= lvdetalle.SelectedItems.Count - 1; i++)
            {
                lvdetalle.SelectedItems[i].Remove();
            }
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            Capa_Negocio.CNguia obj_comp = new Capa_Negocio.CNguia();
            int xidcomp=obj_comp.ingGuia(Convert.ToInt32(cbotipo.SelectedValue.ToString()), 
                dtpfecha.Value.ToString(), Convert.ToInt32(cboproveedor.SelectedValue.ToString()), 
                Convert.ToInt32(cboempleado.SelectedValue.ToString()));
            for(int i = 0; i <= lvdetalle.Items.Count - 1; i++)
            {
                string xres = obj_comp.ingDetGuia(xidcomp, Convert.ToInt32(lvdetalle.Items[i].SubItems[0].Text), 
                    Convert.ToInt32(lvdetalle.Items[i].SubItems[2].Text));
            }
            this.Close();
        }
    }
}
