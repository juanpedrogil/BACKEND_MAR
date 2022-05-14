using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DEV_API_MARISQUERIA.Services
{
    public class MesaService
    {
        SqlConnection sqlConnection;

        public MesaService()
        {
            var configuration = GetConfiguration();
            sqlConnection = new SqlConnection(configuration.GetSection("ConnectionStrings").GetSection("Conexion").Value);
        }

        IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public DataTable GetData(string sp_name, string parametro)
        {
            using (SqlConnection con = sqlConnection)
            {
                DataSet ds = new DataSet();
                try
                {
                    string aux_param = parametro.Replace("&", "&amp;");
                    SqlParameter param;
                    SqlDataAdapter adapter;

                    con.Open();
                    SqlCommand command = new SqlCommand(sp_name, con);
                    command.CommandType = CommandType.StoredProcedure;

                    if (aux_param.Length != 0)
                    {
                        param = new SqlParameter("@id_mesa", aux_param);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int64;
                        command.Parameters.Add(param);
                    }

                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds, sp_name);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return ds.Tables[0];
            }
        }

        public int SetData(string sp_name, string id_mesa, string desc_mesa, string desc_corta_mesa, string estatus)
        {
            using (SqlConnection con = sqlConnection)
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlParameter pId_mesa;
                    SqlParameter pDesc_mesa;
                    SqlParameter pDesc_corta_mesa;
                    SqlParameter pEstatus;

                    SqlDataAdapter adapter;

                    con.Open();
                    SqlCommand command = new SqlCommand(sp_name, con);
                    command.CommandType = CommandType.StoredProcedure;

                    if (id_mesa != null)
                    {
                        pId_mesa = new SqlParameter("@id_mesa", id_mesa);
                        pId_mesa.Direction = ParameterDirection.Input;
                        pId_mesa.DbType = DbType.Int64;
                        command.Parameters.Add(pId_mesa);
                    }

                    pDesc_mesa = new SqlParameter("@DESC_MESA", desc_mesa);
                    pDesc_mesa.Direction = ParameterDirection.Input;
                    pDesc_mesa.DbType = DbType.String;
                    command.Parameters.Add(pDesc_mesa);

                    pDesc_corta_mesa = new SqlParameter("@DESC_CORTA_MESA", desc_corta_mesa);
                    pDesc_corta_mesa.Direction = ParameterDirection.Input;
                    pDesc_corta_mesa.DbType = DbType.String;
                    command.Parameters.Add(pDesc_corta_mesa);

                    pEstatus = new SqlParameter("@ESTATUS", estatus);
                    pEstatus.Direction = ParameterDirection.Input;
                    pEstatus.DbType = DbType.Int64;
                    command.Parameters.Add(pEstatus);

                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds, sp_name);
                    return 1;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        public int DeleteMesa(string sp_name, int id_mesa)
        {
            using (SqlConnection con = sqlConnection)
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlParameter pId_mesa;
                    SqlDataAdapter adapter;

                    con.Open();
                    SqlCommand command = new SqlCommand(sp_name, con);
                    command.CommandType = CommandType.StoredProcedure;

                    pId_mesa = new SqlParameter("@ID_MESA", id_mesa);
                    pId_mesa.Direction = ParameterDirection.Input;
                    pId_mesa.DbType = DbType.String;
                    command.Parameters.Add(pId_mesa);

                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds, sp_name);

                    int res = Convert.ToInt32(ds.Tables[0].Select().Min()["RESULT"]);
                    return res;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

    }
}
