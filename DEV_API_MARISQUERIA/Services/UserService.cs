using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace DEV_API_MARISQUERIA.Services
{
    public class UserService
    {
        SqlConnection sqlConnection;
        public UserService()
        {
            var configuration = GetConfiguration();
            sqlConnection = new SqlConnection(configuration.GetSection("ConnectionStrings").GetSection("Conexion").Value);
        }

        IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange : true);
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

                    if(aux_param.Length != 0)
                    {
                        param = new SqlParameter("@parametrosp", aux_param);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int64;
                        command.Parameters.Add(param);
                    }

                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds,sp_name);
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
        public void SetData(string sp_name, string parametro)
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
                        param = new SqlParameter("@parametrosp", aux_param);
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
            }
        }
        public int SetDataWithReturn(string sp_name, string parametro)
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
                        param = new SqlParameter("@parametrosp", aux_param);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int64;
                        command.Parameters.Add(param);
                    }

                    int ret_val = Convert.ToInt32(command.ExecuteNonQuery());
                    return ret_val;
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
