using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace sysdemo
{
    class ClsSoftware
    {
        public void llenar_cbo(ComboBox cbo,DataTable tb)
        {
            try
            {
                cbo.DataSource = tb;
                cbo.DisplayMember = tb.Columns[1].ToString();
                cbo.ValueMember = tb.Columns[0].ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
