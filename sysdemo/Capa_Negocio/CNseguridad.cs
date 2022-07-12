using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Data;
using System.Data;

namespace Capa_Negocio
{
    public class CNseguridad
    {
        CDseguridad obj = new CDseguridad();// Creando un objeto para acceder a los programas de la capa data
        public string Encriptar(string cadenaAencriptar)
        {
            return obj.Encriptar(cadenaAencriptar);// retorna el resultado a la capa vista.
        }
        public string DesEncriptar(string cadenaAdesencriptar)
        {
            return obj.DesEncriptar(cadenaAdesencriptar);// retorna el resultado a la capa vista.
        }
        public DataTable login(string xusu,string xcon)
        {
            return obj.Login(xusu, xcon);// retorna el resultado a la capa vista.
        }
        public DataTable MostrarData(string xusp)
        {
            return obj.MostrarData(xusp);
        }
    }
}
