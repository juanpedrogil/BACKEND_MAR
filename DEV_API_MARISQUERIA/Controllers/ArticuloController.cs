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
    public class ArticuloController : Controller
    {

        public ArticuloService db = new ArticuloService(); 

        [HttpGet]
        public IEnumerable<Articulo> getAll()
        {
            try

            {
                DataTable dt = db.GetData("ODS.ODS_SP_GETALL_ARTICULO", "");
                var result = (from rw in dt.Select()
                              select new Articulo
                              {
                                  ID_ARTICULO = Convert.ToInt32(rw["ID_ARTICULO"].ToString()),
                                  DESC_ARTICULO = rw["DESC_ARTICULO"].ToString(),
                                  DESC_CORTA_ARTICULO = rw["DESC_CORTA_ARTICULO"].ToString(),
                                  UPC_CVE = rw["UPC_CVE"].ToString(),
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


        [HttpGet("{id_articulo}")]
        public IEnumerable<Articulo> GetArticulo(string id_articulo)
        {
            try

            {
                DataTable dt = db.GetData("ODS.ODS_SP_GET_ARTICULO", id_articulo);
                var result = (from rw in dt.Select()
                              select new Articulo
                              {
                                  ID_ARTICULO = Convert.ToInt32(rw["ID_ARTICULO"].ToString()),
                                  DESC_ARTICULO = rw["DESC_ARTICULO"].ToString(),
                                  DESC_CORTA_ARTICULO = rw["DESC_CORTA_ARTICULO"].ToString(),
                                  UPC_CVE = rw["UPC_CVE"].ToString(),
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
        public ActionResult InsertArticulo(Articulo articulo)
        {
            try
            {
                if (db.SetData("ODS.ODS_SP_INSERT_ARTICULO", null, articulo.DESC_ARTICULO, articulo.DESC_CORTA_ARTICULO, articulo.UPC_CVE, articulo.ESTATUS.ToString()) == 1)
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
        public ActionResult UpdateArticulo(Articulo articulo)
        {
            try
            {

                if (db.SetData("ODS.ODS_SP_UPDATE_ARTICULO", articulo.ID_ARTICULO.ToString(), articulo.DESC_ARTICULO, articulo.DESC_CORTA_ARTICULO, articulo.UPC_CVE, articulo.ESTATUS.ToString()) == 1)
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

        [HttpDelete("{id_articulo}")]
        public ActionResult DeleteArticulo(int id_articulo)
        {
            try
            {
                if (db.DeleteArticulo("ODS.ODS_SP_DELETE_ARTICULO", id_articulo) == 1)
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