using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Data;
namespace Capa_Negocio
{
    public class CNguia
    {
        CDguia obj = new CDguia();
        public DataTable ListaGuiaFecha(string xfecdesde,string xfechasta)
        {
            return obj.ListaGuiaFecha(xfecdesde, xfechasta);
        }
        public DataTable Mostrardata(string xusp)
        {
            return obj.MostrarData(xusp);
        }
        public int ingGuia(int xidTip,string xfecComp,int xidprove,int xidemp)
        {
            return obj.ingGuia(xidTip, xfecComp, xidprove, xidemp);
        }
        public string ingDetGuia(int xidGui,int xidpro,int xcan)
        {
            return obj.ingDetaGuia(xidGui, xidpro, xcan);
        }
    }
}
