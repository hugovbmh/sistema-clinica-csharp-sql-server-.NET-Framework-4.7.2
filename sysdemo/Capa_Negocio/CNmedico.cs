using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Data;

namespace Capa_Negocio
{
    public class CNmedico
    {
        CDmedico obj = new CDmedico();
        public DataTable BusCitasMed(int xidmed)
        {
            return obj.BusCitasMed(xidmed);
        }
        public DataTable BusMedEsp(int xidesp)
        {
            return obj.BusMedEsp(xidesp);
        }
        public DataTable MostrarData(string xusp)
        {
            return obj.MostrarData(xusp);
        }
        public DataTable mostrar()
        {
            return obj.Mostrar();
        }
        public DataTable MostrarApellido(string xape)
        {
            return obj.MostrarApellido(xape);
        }

        public DataTable BusMedicoPorID(int xidmed)
        {
            return obj.BusMedicoporID(xidmed);
        }
        public string EliminaMedico(int xid)
        {
            return obj.EliminaMedico(xid);
        }
        public string ingMedico(string xnom,string xape,string xdni,int xdis, int xesp,string xnro,string xmov)
        {
            return obj.ingMedico(xnom, xape, xdni, xdis, xesp, xnro, xmov);
        }
        public string ModMedico(int xid,string xnom, string xape, string xdni, int xdis, int xesp, string xnro, string xmov)
        {
            return obj.ModMedico(xid,xnom, xape, xdni, xdis, xesp, xnro, xmov);
        }

    }
}
