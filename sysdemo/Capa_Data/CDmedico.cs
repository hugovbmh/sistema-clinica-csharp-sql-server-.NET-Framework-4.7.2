using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Data
{
    public class CDmedico
    {
        SqlConnection cn = new SqlConnection();
        public DataTable BusDataId(string xusp,int xid)
        {
            cn.ConnectionString = CDconexion.cnx;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(xusp + " " + xid, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable BusCitasMed(int xidmed)
        {
            cn.ConnectionString = CDconexion.cnx;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("usp_CitasMed2"+xidmed, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable BusMedEsp(int xidesp)
        {
            cn.ConnectionString = CDconexion.cnx;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("usp_MedEsp" + xidesp, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
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
        public DataTable Mostrar()
        {
            cn.ConnectionString = CDconexion.cnx;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("usp_Listamedicos", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable MostrarApellido(string xape)
        {
            cn.ConnectionString = CDconexion.cnx;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("usp_BuscaMedicos '" + xape + "'", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable BusMedicoporID(int xidmed)
        {
            cn.ConnectionString = CDconexion.cnx;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("usp_BusMedicoPorID " + xidmed, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public string ingMedico(string xnom,string xape,string xdni,int xdis,int xesp,string xnro,string xmov)
        {
            cn.ConnectionString = CDconexion.cnx;
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_ingMed", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //Creando los parámetros;
            SqlParameter ParNom = new SqlParameter();
            ParNom.ParameterName = "@nom_med";
            ParNom.SqlDbType = SqlDbType.VarChar;
            ParNom.Value = xnom;

            SqlParameter ParApe = new SqlParameter();
            ParApe.ParameterName = "@ape_med";
            ParApe.SqlDbType = SqlDbType.VarChar;
            ParApe.Value = xape;

            SqlParameter ParDni = new SqlParameter();
            ParDni.ParameterName = "@dni_med";
            ParDni.SqlDbType = SqlDbType.Char;
            ParDni.Value = xdni;

            SqlParameter ParDis = new SqlParameter();
            ParDis.ParameterName = "@id_dis";
            ParDis.SqlDbType = SqlDbType.Int;
            ParDis.Value = xdis;

            SqlParameter ParEsp = new SqlParameter();
            ParEsp.ParameterName = "@id_esp";
            ParEsp.SqlDbType = SqlDbType.Int;
            ParEsp.Value = xesp;

            SqlParameter ParNro = new SqlParameter();
            ParNro.ParameterName = "@nro_col";
            ParNro.SqlDbType = SqlDbType.VarChar;
            ParNro.Value = xnro;

            SqlParameter ParMov = new SqlParameter();
            ParMov.ParameterName = "@cel_med";
            ParMov.SqlDbType = SqlDbType.Char;
            ParMov.Value = xmov;

            // Agregando los parámetros al sqlcommand
            cmd.Parameters.Add(ParNom);
            cmd.Parameters.Add(ParApe);
            cmd.Parameters.Add(ParDni);
            cmd.Parameters.Add(ParDis);
            cmd.Parameters.Add(ParEsp);
            cmd.Parameters.Add(ParNro);
            cmd.Parameters.Add(ParMov);

            try
            {
                cmd.ExecuteNonQuery();// ejecuta el comando
                cn.Close();
                return "Ok";
            }
            catch(Exception ex)
            {
                cn.Close();
                return ex.Message;
            }
        }

        public string ModMedico(int xid, string xnom, string xape, string xdni, int xdis, int xesp, string xnro, string xmov)
        {
            cn.ConnectionString = CDconexion.cnx;
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_ModMed", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Creando los parámetros;

            SqlParameter ParId = new SqlParameter();
            ParId.ParameterName = "id_med";
            ParId.SqlDbType = SqlDbType.Int;
            ParId.Value = xid;

            SqlParameter ParNom = new SqlParameter();
            ParNom.ParameterName = "@nom_med";
            ParNom.SqlDbType = SqlDbType.VarChar;
            ParNom.Value = xnom;

            SqlParameter ParApe = new SqlParameter();
            ParApe.ParameterName = "@ape_med";
            ParApe.SqlDbType = SqlDbType.VarChar;
            ParApe.Value = xape;

            SqlParameter ParDni = new SqlParameter();
            ParDni.ParameterName = "@dni_med";
            ParDni.SqlDbType = SqlDbType.Char;
            ParDni.Value = xdni;

            SqlParameter ParDis = new SqlParameter();
            ParDis.ParameterName = "@id_dis";
            ParDis.SqlDbType = SqlDbType.Int;
            ParDis.Value = xdis;

            SqlParameter ParEsp = new SqlParameter();
            ParEsp.ParameterName = "@id_esp";
            ParEsp.SqlDbType = SqlDbType.Int;
            ParEsp.Value = xesp;

            SqlParameter ParNro = new SqlParameter();
            ParNro.ParameterName = "@nro_col";
            ParNro.SqlDbType = SqlDbType.VarChar;
            ParNro.Value = xnro;

            SqlParameter ParMov = new SqlParameter();
            ParMov.ParameterName = "@cel_med";
            ParMov.SqlDbType = SqlDbType.Char;
            ParMov.Value = xmov;

            // Agregando los parámetros al sqlcommand
            cmd.Parameters.Add(ParId);
            cmd.Parameters.Add(ParNom);
            cmd.Parameters.Add(ParApe);
            cmd.Parameters.Add(ParDni);
            cmd.Parameters.Add(ParDis);
            cmd.Parameters.Add(ParEsp);
            cmd.Parameters.Add(ParNro);
            cmd.Parameters.Add(ParMov);

            try
            {
                cmd.ExecuteNonQuery();// ejecuta el comando
                cn.Close();
                return "Ok";
            }
            catch (Exception ex)
            {
                cn.Close();
                return ex.Message;
            }
        }
        public string EliminaMedico(int xid)
        {
            cn.ConnectionString = CDconexion.cnx;
            cn.Open();
            SqlCommand cmd = new SqlCommand("usp_EliMed", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter ParId = new SqlParameter();
            ParId.ParameterName = "@id";
            ParId.SqlDbType = SqlDbType.Int;
            ParId.Value = xid;

            cmd.Parameters.Add(ParId);

            try
            {
                cmd.ExecuteNonQuery();// ejecuta el comando
                cn.Close();
                return "Ok";
            }
            catch (Exception ex)
            {
                cn.Close();
                return ex.Message;
            }
        }

    }
}
