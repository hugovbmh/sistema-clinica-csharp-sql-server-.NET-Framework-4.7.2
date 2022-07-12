using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Capa_Data
{
    public class CDmantenimiento
    {
        SqlConnection cn = new SqlConnection();
        public DataTable MostrarEsp()
        {
            cn.ConnectionString = CDconexion.cnx;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("usp_ListaConsultorios", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable BuscarEsp(string xnom)
        {
            cn.ConnectionString = CDconexion.cnx;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("usp_BusEsp '" + xnom + "'",cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public string IngEspecialidad(string xnom)
        {
            cn.ConnectionString = CDconexion.cnx;
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_IngEsp", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter ParId = new SqlParameter();
            ParId.ParameterName = "@nom";
            ParId.SqlDbType = SqlDbType.VarChar;
            ParId.Value = xnom;
            cmd.Parameters.Add(ParId);
            try
            {
                cmd.ExecuteNonQuery();
                cn.Close();
                return "Ok";
            }catch(Exception ex)
            {
                cn.Close();
                return ex.Message;
            }
        }

        public string ModEspecialidad(int xid,string xnom)
        {
            cn.ConnectionString = CDconexion.cnx;
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_ModEsp", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            // el parámetro Id
            SqlParameter ParId = new SqlParameter();
            ParId.ParameterName = "@id";
            ParId.SqlDbType = SqlDbType.Int;
            ParId.Value = xid;
            // el parámetro Nombre
            SqlParameter ParNom = new SqlParameter();
            ParNom.ParameterName = "@nom";
            ParNom.SqlDbType = SqlDbType.VarChar;
            ParNom.Value = xnom;

            cmd.Parameters.Add(ParId);
            cmd.Parameters.Add(ParNom);
            try
            {
                cmd.ExecuteNonQuery();
                cn.Close();
                return "Ok";
            }
            catch (Exception ex)
            {
                cn.Close();
                return ex.Message;
            }
        }

        public DataTable Mostrar()
        {
            cn.ConnectionString = CDconexion.cnx;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("usp_ListaEspecialidad", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

    }
}
