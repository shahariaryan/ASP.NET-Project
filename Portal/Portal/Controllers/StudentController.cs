using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            PortalEntities db = new PortalEntities();
            
                var students = (from u in db.Users
                                where u.type== "Student"
                                select u).ToList();
                return View(students);

            
        }
    }
}