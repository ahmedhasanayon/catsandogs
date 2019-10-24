using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace CatsAndDogs.Controllers
{
    public class DbController : Controller
    {
        string connectionString = @"data Source = DESKTOP-JSCNFT6; Initial Catalog = catsdogs; Integrated Security = True";
        [HttpGet]
        public ActionResult AdminView()
        {
            DataTable alluseres = new DataTable();
            using (SqlConnection scon = new SqlConnection(connectionString))
            {
                scon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("select * from users", scon);
                sqlda.Fill(alluseres);
            }
            return View(alluseres);
        }

        // GET: Db/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Db/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Db/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Db/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Db/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Db/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Db/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
