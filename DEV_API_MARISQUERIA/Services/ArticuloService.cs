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
    public class ArticuloService
    {
        SqlConnection sqlConnection;

        public ArticuloService()
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
                        param = new SqlParameter("@id_articulo", aux_param);
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

        public int SetData(string sp_name, string id_articulo, string desc_articulo, string desc_corta_articulo, string upc_cve, string estatus)
        {
            using (SqlConnection con = sqlConnection)
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlParameter pId_articulo;
                    SqlParameter pDesc_articulo;
                    SqlParameter pDesc_corta_articulo;
                    SqlParameter pUpc_cve;
                    SqlParameter pEstatus;

                    SqlDataAdapter adapter;

                    con.Open();
                    SqlCommand command = new SqlCommand(sp_name, con);
                    command.CommandType = CommandType.StoredProcedure;

                    if (id_articulo != null)
                    {
                        pId_articulo = new SqlParameter("@id_articulo", id_articulo);
                        pId_articulo.Direction = ParameterDirection.Input;
                        pId_articulo.DbType = DbType.Int64;
                        command.Parameters.Add(pId_articulo);
                    }

                    pDesc_articulo = new SqlParameter("@DESC_ARTICULO", desc_articulo);
                    pDesc_articulo.Direction = ParameterDirection.Input;
                    pDesc_articulo.DbType = DbType.String;
                    command.Parameters.Add(pDesc_articulo);

                    pDesc_corta_articulo = new SqlParameter("@DESC_CORTA_ARTICULO", desc_corta_articulo);
                    pDesc_corta_articulo.Direction = ParameterDirection.Input;
                    pDesc_corta_articulo.DbType = DbType.String;
                    command.Parameters.Add(pDesc_corta_articulo);

                    pUpc_cve = new SqlParameter("@UPC_CVE", upc_cve);
                    pUpc_cve.Direction = ParameterDirection.Input;
                    pUpc_cve.DbType = DbType.String;
                    command.Parameters.Add(pUpc_cve);

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

        public int DeleteArticulo(string sp_name, int id_articulo)
        {
            using (SqlConnection con = sqlConnection)
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlParameter pId_articulo;
                    SqlDataAdapter adapter;

                    con.Open();
                    SqlCommand command = new SqlCommand(sp_name, con);
                    command.CommandType = CommandType.StoredProcedure;

                    pId_articulo = new SqlParameter("@ID_ARTICULO", id_articulo);
                    pId_articulo.Direction = ParameterDirection.Input;
                    pId_articulo.DbType = DbType.String;
                    command.Parameters.Add(pId_articulo);

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
