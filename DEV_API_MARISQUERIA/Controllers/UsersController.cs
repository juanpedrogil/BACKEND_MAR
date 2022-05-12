using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DEV_API_MARISQUERIA.Models;
using DEV_API_MARISQUERIA.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DEV_API_MARISQUERIA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        UserService db = new UserService();


        [HttpGet]
        public IEnumerable<User> get()
        {
            try

            {
                DataTable dt = db.GetData("ADM.SP_GET_ALLUSERS", "");
                var result = (from rw in dt.Select()
                              select new User
                              {
                                  ID_USER = Convert.ToInt32(rw["ID_USER"]),
                                  USERNAME = Convert.ToString(rw["USERNAME"]),
                                  //PASSWORD = Convert.ToString(rw["PASSWORD"]),
                                  NOMBRE = Convert.ToString(rw["NOMBRE"]),
                                  APELLIDO = Convert.ToString(rw["APELLIDO"]),
                                  ESTATUS = Convert.ToInt32(rw["ESTATUS"]),
                                  LOADDATE = Convert.ToDateTime(rw["LOADDATE"]),
                                  UPDATEDATE = Convert.ToDateTime(rw["UPDATEDATE"])
                              }
                                  );
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


        [HttpGet("{id_user}")]
        public IEnumerable<User> getUser(int id_user)
        {
            try

            {
                DataTable dt = db.GetData("ADM.SP_GET_USER", id_user+"");
                var result = (from rw in dt.Select()
                              select new User
                              {
                                  ID_USER = Convert.ToInt32(rw["ID_USER"]),
                                  USERNAME = Convert.ToString(rw["USERNAME"]),
                                  //PASSWORD = Convert.ToString(rw["PASSWORD"]),
                                  NOMBRE = Convert.ToString(rw["NOMBRE"]),
                                  APELLIDO = Convert.ToString(rw["APELLIDO"]),
                                  ESTATUS = Convert.ToInt32(rw["ESTATUS"]),
                                  LOADDATE = Convert.ToDateTime(rw["LOADDATE"]),
                                  UPDATEDATE = Convert.ToDateTime(rw["UPDATEDATE"])
                              }
                                  );
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(User parametros)
        {
            try
            {
                //var aux_param = (JObject)JsonConvert.DeserializeObject(parametros);
                /*if (db.SetData("ADM.SP_INSERT_USER", aux_param["username"].Value<string>()
                    , aux_param["password"].Value<string>(), aux_param["nombre"].Value<string>()
                    , aux_param["apellido"].Value<string>(), aux_param["estatus"].Value<string>()) == 1)*/
                if (db.SetData("ADM.SP_INSERT_USER", null, parametros.USERNAME, parametros.PASSWORD, parametros.NOMBRE
                    , parametros.APELLIDO, parametros.ESTATUS.ToString()) == 1)
                {
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [HttpPost("{id_user}")]
        public ActionResult DeleteUser(int id_user)
        {
            try
            {
                if (db.DeleteUser("ADM.SP_DELETE_USER", id_user) == 1)
                {
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        public ActionResult UpdateUser(User usuarioActualizado)
        {
            try
            {
                if (db.SetData("ADM.SP_UPDATE_USER",usuarioActualizado.ID_USER.ToString(), usuarioActualizado.USERNAME, usuarioActualizado.PASSWORD, usuarioActualizado.NOMBRE
                    , usuarioActualizado.APELLIDO, usuarioActualizado.ESTATUS.ToString()) == 1)
                {
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }
    }
}