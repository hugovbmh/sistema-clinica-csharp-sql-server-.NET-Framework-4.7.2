using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Data;

namespace Capa_Negocio
{
    public class CNmantenimiento
    {
        CDmantenimiento obj = new CDmantenimiento();
        public DataTable mostrarEsp()
        {
            return obj.MostrarEsp();
        }
        public DataTable BusEsp(string xnom)
        {
            return obj.BuscarEsp(xnom);
        }
        public string IngEspecialidad(string xnom)
        {
            return obj.IngEspecialidad(xnom);
        }
        public string ModEspecialidad(int xid,string xnom)
        {
            return obj.ModEspecialidad(xid, xnom);
        }
        public DataTable mostrar()
        {
            return obj.Mostrar();
        }

    }
}
