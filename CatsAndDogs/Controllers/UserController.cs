using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatsAndDogs.Models;

namespace CatsAndDogs.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Profile()
        {

            var Users = new user() {
                
                name = "Ahmed"
            };
            return View(Users);
        }
    }
}