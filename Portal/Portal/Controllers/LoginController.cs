using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Portal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User u)
        {
            PortalEntities db = new PortalEntities();
            var user = db.Users.FirstOrDefault(e => e.uid == u.uid);
            if (user != null)
            {
                if (user.password.Trim() == u.password && u.password != null)
                {

                    FormsAuthentication.SetAuthCookie(user.userid.ToString(), true);
                    Session["name"] = user.name;
                    Session["id"] = user.userid;

                    if (user.type.Trim() == "Feculty")
                    {
                        return RedirectToAction("Home", "Feculty");
                    }
                    else if(user.type.Trim() == "Admin")
                    {
                        return RedirectToAction("Home", "Admin");
                    }
                    else if (user.type.Trim() == "Student")
                    {
                        return RedirectToAction("Home", "Student");
                    }

                }
                TempData["ErrorMessage"] = "Incorrect Username/Password";
                return View();
            }
            TempData["ErrorMessage"] = "Feculty Doesnot Exist";
            return View();
        }
        public ActionResult Logout()
        {
            Session["usertype"] = null;
            Session["name"] = null;
            Session["id"] = null;
            FormsAuthentication.SignOut();
            return Redirect("/Home");
        }

    }

}

