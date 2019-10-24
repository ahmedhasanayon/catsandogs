using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace CatsAndDogs.Controllers
{
    public class HomeController : Controller
    {
        string connectionString = @"data Source = DESKTOP-JSCNFT6; Initial Catalog = catsdogs; Integrated Security = True";
        public ActionResult Index()
        {
             Session["userActive"] = 0;
            return View();
        }
        [HttpGet]
        public ActionResult userProfile()
        {
            var dtbUser = new DataTable();
            var userIdActive = Session["userActive"];

            using (var sqlCon = new SqlConnection(connectionString))
            {

                sqlCon.Open();
                if (!Session["userActive"].Equals(0)) {
                    SqlDataAdapter sqlDa1 = new SqlDataAdapter("select * from users where id = '" + userIdActive + "'", sqlCon);
                    sqlDa1.Fill(dtbUser);
                    
                }

                
            }

            return View(dtbUser);


        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(FormCollection formCollection)
        {
            string email = formCollection["email"];
            string password = formCollection["password"];

            using (var sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "select * from users where email='" + email + "'and passwords='" + password + "'";


                var sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                if (dr.Read())
                {
                    int userIdLoggedIn = dr.GetInt32(0);
                    Session["userActive"] = userIdLoggedIn;
                    return RedirectToAction("UserProfile", "Home", new { id = userIdLoggedIn });

                }
                else
                {
                    return Content("login usuccessful");


                }
            }
        }



        public ActionResult SignUP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUP(FormCollection formCollection)
        {
            string email = formCollection["emailInput"];
            string userName = formCollection["usernameInput"];
            string password = formCollection["passwordInput"];
            string fullName = formCollection["fnInput"];

            using (var sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "insert into users values(@email,@username,@passwords,@full_name)";


                var sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@email", email);
                sqlCmd.Parameters.AddWithValue("@username", userName);
                sqlCmd.Parameters.AddWithValue("@passwords", password);
                sqlCmd.Parameters.AddWithValue("@full_name", fullName);
                
                sqlCmd.ExecuteNonQuery();
            }

            return View();
        }
    }
}