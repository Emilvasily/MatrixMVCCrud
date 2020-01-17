using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MatrixMVCCrud.Models.EntityFramework;

namespace MatrixMVCCrud.Controllers
{

    public class LoginController : Controller
    {

        MatrixMVCCrudDBEntities matrixMVCCrudDBEntities = new MatrixMVCCrudDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string userName, string password)
        {
            var users = matrixMVCCrudDBEntities.USERS.FirstOrDefault(x => x.NAME.ToLower() == userName && x.PASSWORD == password);
            if (users != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(users);
        }
    }
}