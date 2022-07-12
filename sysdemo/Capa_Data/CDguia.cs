using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Capa_Data
{
    public class CDguia
    {
        SqlConnection cn = new SqlConnection(CDconexion.cnx);
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        public DataTable ListaGuiaFecha(string xfecdesde,string xfechasta)
        {
            SqlCommand cmd=new SqlCommand("usp_GuiaFecha '" + xfecdesde.Substring(0,10) + "','"  + xfechasta.Substring(0, 10) + "'",cn);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;// retorna la tabla con el resultado de ejecutar el procedimiento almacenado usp_GuiaFecha
        }
        public DataTable MostrarData(string xusp)
        {
            cn.ConnectionString = CDconexion.cnx;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(xusp, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public string ingDetaGuia(int xidGui,int xidpro,int xcan)
        {
            cn.ConnectionString = CDconexion.cnx;
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_detaGuia", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idgui", SqlDbType.Int).Value = xidGui;
            cmd.Parameters.Add("@idpro", SqlDbType.Int).Value = xidpro;
            cmd.Parameters.Add("@canpro", SqlDbType.Decimal).Value = xcan;
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
        public int ingGuia(int xidTip,string xfecComp,int xidprove,int xidemp)
        {
            cn.ConnectionString = CDconexion.cnx;
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_inGuia", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter ParIdComp = new SqlParameter();
            ParIdComp.ParameterName = "@idguia";
            ParIdComp.SqlDbType = SqlDbType.Int;
            ParIdComp.Direction = ParameterDirection.Output;
            ParIdComp.Value = 1;
            cmd.Parameters.Add(ParIdComp);

            cmd.Parameters.Add("@idtipdoc", SqlDbType.Int).Value = xidTip;
            cmd.Parameters.Add("@fecguia", SqlDbType.Date).Value = xfecComp;
            cmd.Parameters.Add("@idprov", SqlDbType.Int).Value = xidprove;
            cmd.Parameters.Add("@idemp", SqlDbType.Int).Value = xidemp;
            try
            {
                cmd.ExecuteNonQuery();
                cn.Close();
                return Convert.ToInt32(cmd.Parameters["@idguia"].Value);
            }
            catch (Exception ex)
            {
                cn.Close();
                return 0;
            }
        }
    }
}
