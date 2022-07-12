using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Data
{
    public class CDseguridad
    {
        SqlConnection cn = new SqlConnection();// cn la variable de conexion
        public string Encriptar(string cadenaAencriptar)
        {
            string result = string.Empty;
            // Convertir una cadena de caracteres a bytes:
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadenaAencriptar);
            result = Convert.ToBase64String(encryted);//convertir los bytes en binario.
            return result;
        }
        public string DesEncriptar(string cadenaAdesencriptar)
        {
            string result = string.Empty;
            // Convertir una cadena de caracteres a bytes:
            byte[] decryted = Convert.FromBase64String(cadenaAdesencriptar);//convertir a mariz de enteros.
            result= System.Text.Encoding.Unicode.GetString(decryted);// convertir en cadena
            return result;
        }
        public DataTable Login(string xusu, string xcon)
        {
            cn.ConnectionString = CDconexion.cnx;// se crea la cconexion con la bd
            DataTable dt = new DataTable();// crear una tabla en la memoria
            // ejecutaremos el proced. almacenado verifica_login, el cual recibira el usuario y la conexion
            SqlCommand cmd = new SqlCommand("verifica_login '" + xusu + "', '" + xcon + "'", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);// el objeto da ejecuta el contenido de la variable cmd
            da.Fill(dt);// el resultado de la ejecución del proced. almacenado se guarda en la tabla(dt)
            return dt;
        }
        public DataTable MostrarData(string xusp)// en xusp debe llegar el nombre de un proced. almacenado
        {
            cn.ConnectionString = CDconexion.cnx;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(xusp, cn);// se crea un comando
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);//rellenar la tabla en memoria
            return dt;
        }
    }
}
