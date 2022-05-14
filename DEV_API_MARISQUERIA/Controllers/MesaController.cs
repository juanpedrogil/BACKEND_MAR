using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DEV_API_MARISQUERIA.Models;
using DEV_API_MARISQUERIA.Services;
using Microsoft.AspNetCore.Mvc;

namespace DEV_API_MARISQUERIA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : Controller
    {
        private MesaService db = new MesaService();

        [HttpGet]
        public IEnumerable<Mesa> GetAll()
        {
            try

            {
                DataTable dt = db.GetData("ODS.ODS_SP_GETALL_MESA", "");
                var result = (from rw in dt.Select()
                              select new Mesa
                              {
                                  ID_MESA = Convert.ToInt32(rw["ID_MESA"].ToString()),
                                  DESC_MESA = rw["DESC_MESA"].ToString(),
                                  DESC_CORTA_MESA = rw["DESC_CORTA_MESA"].ToString(),
                                  ESTATUS = Convert.ToInt32(rw["ESTATUS"].ToString()),
                                  UPDATEDATE = Convert.ToDateTime(rw["UPDATEDATE"].ToString()),
                                  LOADDATE = Convert.ToDateTime(rw["LOADDATE"].ToString())
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

        [HttpGet("{id_mesa}")]
        public IEnumerable<Mesa> GetMesa(int id_mesa)
        {
            try

            {
                DataTable dt = db.GetData("ODS.ODS_SP_GET_MESA", id_mesa + "");
                var result = (from rw in dt.Select()
                              select new Mesa

                              {
                                  ID_MESA = Convert.ToInt32(rw["ID_MESA"].ToString()),
                                  DESC_MESA = rw["DESC_MESA"].ToString(),
                                  DESC_CORTA_MESA = rw["DESC_CORTA_MESA"].ToString(),
                                  ESTATUS = Convert.ToInt32(rw["ESTATUS"].ToString()),
                                  UPDATEDATE = Convert.ToDateTime(rw["UPDATEDATE"].ToString()),
                                  LOADDATE = Convert.ToDateTime(rw["LOADDATE"].ToString())
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

        [HttpPost]
        public ActionResult InsertMesa(Mesa mesa)
        {
            try
            {
                if (db.SetData("ODS.ODS_SP_INSERT_MESA", null, mesa.DESC_MESA, mesa.DESC_CORTA_MESA, mesa.ESTATUS.ToString()) == 1)
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