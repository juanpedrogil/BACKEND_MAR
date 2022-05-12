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
                        param = new SqlParameter("@usuario", aux_param);
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
        public int SetData(string sp_name, string id_user, string username, string password, string nombre, string apellido, string estatus)
        {
            using (SqlConnection con = sqlConnection)
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlParameter pId_user;
                    SqlParameter pUsername;
                    SqlParameter pPassword;
                    SqlParameter pNombre;
                    SqlParameter pApellido;
                    SqlParameter pEstatus;
                    SqlDataAdapter adapter;

                    con.Open();
                    SqlCommand command = new SqlCommand(sp_name, con);
                    command.CommandType = CommandType.StoredProcedure;

                    if(id_user != null)
                    {
                        pId_user = new SqlParameter("@usuario", id_user);
                        pId_user.Direction = ParameterDirection.Input;
                        pId_user.DbType = DbType.Int64;
                        command.Parameters.Add(pId_user);
                    }

                    pUsername = new SqlParameter("@USERNAME", username);
                    pUsername.Direction = ParameterDirection.Input;
                    pUsername.DbType = DbType.String;
                    command.Parameters.Add(pUsername);

                    pPassword = new SqlParameter("@PASSWORD", password);
                    pPassword.Direction = ParameterDirection.Input;
                    pPassword.DbType = DbType.String;
                    command.Parameters.Add(pPassword);

                    pNombre = new SqlParameter("@NOMBRE", nombre);
                    pNombre.Direction = ParameterDirection.Input;
                    pNombre.DbType = DbType.String;
                    command.Parameters.Add(pNombre);

                    pApellido = new SqlParameter("@APELLIDO", apellido);
                    pApellido.Direction = ParameterDirection.Input;
                    pApellido.DbType = DbType.String;
                    command.Parameters.Add(pApellido);

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

        public int DeleteUser(string sp_name, int id_user)
        {
            using (SqlConnection con = sqlConnection)
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlParameter pId_User;
                    SqlDataAdapter adapter;

                    con.Open();
                    SqlCommand command = new SqlCommand(sp_name, con);
                    command.CommandType = CommandType.StoredProcedure;

                    pId_User = new SqlParameter("@ID_USER", id_user);
                    pId_User.Direction = ParameterDirection.Input;
                    pId_User.DbType = DbType.String;
                    command.Parameters.Add(pId_User);

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
