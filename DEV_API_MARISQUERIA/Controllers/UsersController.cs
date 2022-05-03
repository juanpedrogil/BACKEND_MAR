using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DEV_API_MARISQUERIA.Models;
using DEV_API_MARISQUERIA.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            catch(Exception e)
            {
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}