using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            User u = new User();
            u.courseid = Convert.ToInt32("1006");
            return View(u);
        }

        [HttpPost]
        public ActionResult CreateUser(User u)
        {
            if (ModelState.IsValid)
            {
                PortalEntities db = new PortalEntities();
                db.Users.Add(u);
                db.SaveChanges();
                return RedirectToAction("CheckUsers");
            }
            return View();
        }

        public ActionResult CheckUsers()
        {
            PortalEntities db = new PortalEntities();
            var users = db.Users.ToList();
            return View(users);
        }

        [HttpPost]
        public ActionResult CheckUsers(string searchuser)
        {
            PortalEntities db = new PortalEntities();
            var users = (from u in db.Users
                         where u.name.Contains(searchuser)
                         select u).ToList();
            return View(users);
        }

       
        public ActionResult EditUser(int id)
        {
            PortalEntities db = new PortalEntities();
            var user = (from g in db.Users
                         where g.userid == id
                         select g).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(User u)
        {
            PortalEntities db = new PortalEntities();
            var user = (from us in db.Users
                          where us.userid == u.userid
                          select us).FirstOrDefault();

            user.uid = u.uid;
            user.name = u.name;
            user.email = u.email;
            user.department = u.department;
            user.password= u.password;
            db.SaveChanges();
            return RedirectToAction("CheckUsers");
        }

        public ActionResult DeleteUser(int id)
        {
            using (PortalEntities db = new PortalEntities())
            {
               var userr = (from uu in db.Users
                              where uu.userid == id
                              select uu).FirstOrDefault();
                return View(userr);
            }
        }

        [HttpPost]
        [ActionName("DeleteUser")]
        public ActionResult DeleteUsers(int id)
        {
            PortalEntities db = new PortalEntities();
            var userr = (from uu in db.Users
                          where uu.userid == id
                          select uu).FirstOrDefault();
            db.Users.Remove(userr);
            db.SaveChanges();
            return RedirectToAction("CheckUsers");
        }

        public ActionResult CreateCourse()
        {
            Cours c = new Cours();
            return View(c);
        }

        [HttpPost]
        public ActionResult CreateCourse(Cours c)
        {
            if (ModelState.IsValid)
            {
                PortalEntities db = new PortalEntities();
                db.Courses.Add(c);
                db.SaveChanges();
                return RedirectToAction("CheckCourse");
            }
            return View();
        }

        public ActionResult CheckCourse()
        {
            PortalEntities db = new PortalEntities();
            var courses = db.Courses.ToList();
            return View(courses);
        }

        [HttpPost]
        public ActionResult CheckCourse(string searchcourse)
        {
            PortalEntities db = new PortalEntities();
            var course = (from u in db.Courses
                         where u.name.Contains(searchcourse)
                         select u).ToList();
            return View(course);
        }

        public ActionResult CheckCourseDetails(int Id)
        {
            PortalEntities db = new PortalEntities();

            var cour = (from c in db.Courses
                        where c.id == Id
                        select c).FirstOrDefault();

            return View(cour);
        }

        public ActionResult EditCourse(int id)
        {
            PortalEntities db = new PortalEntities();
            var course = (from c in db.Courses
                        where c.id == id
                        select c).FirstOrDefault();
            return View(course);
        }
        [HttpPost]
        public ActionResult EditCourse(Cours c)
        {
            PortalEntities db = new PortalEntities();
            var course = (from cs in db.Courses
                        where cs.id == c.id
                        select cs).FirstOrDefault();

           
            course.name = c.name;
            course.department = c.department;
            course.section = c.section;
            course.time = c.time;
            db.SaveChanges();
            return RedirectToAction("CheckCourse");
        }
        public ActionResult DeleteCourse(int id)
        {
            PortalEntities db = new PortalEntities();
            var coursee= (from c in db.Courses
                          where c.id == id
                          select c).FirstOrDefault();
            return View(coursee);
        }

        [HttpPost]
        [ActionName("DeleteCourse")]
        public ActionResult DeleteCourses(int id)
        {
            PortalEntities db = new PortalEntities();
            var courses = (from cc in db.Courses
                         where cc.id == id
                         select cc).FirstOrDefault();
            db.Courses.Remove(courses);
            db.SaveChanges();
            return RedirectToAction("CheckCourse");
        }
        public ActionResult CheckRequests()
        {
            PortalEntities db = new PortalEntities();
            var req= db.Requests.ToList();
            return View(req);
        }

        [HttpPost]
        public ActionResult CheckRequests(string searchreq)
        {
            PortalEntities db = new PortalEntities();
            var req = (from r in db.Requests
                          where r.coursename.Contains(searchreq)
                          select r).ToList();
            return View(req);
        }


        public ActionResult CheckRequestsDetails(int id)
        {

            PortalEntities db = new PortalEntities();

            var user = (from m in db.Users
                        where m.userid == id
                        select m).FirstOrDefault();

            return View(user);
        }
        public ActionResult EditRequest(int id)
        {
            PortalEntities db = new PortalEntities();
            var req= (from r in db.Requests
                          where r.id == id
                          select r).FirstOrDefault();
            return View(req);
        }
        [HttpPost]
        public ActionResult EditRequest(Request r)
        {
            PortalEntities db = new PortalEntities();
            var req = (from rq in db.Requests
                          where rq.id == r.id
                          select rq).FirstOrDefault();


            req.coursename = r.coursename;
            req.department = r.department;
            req.status = "Approved";
            db.SaveChanges();
            return RedirectToAction("CheckRequests");
        }
        public ActionResult DeleteRequest(int id)
        {
            PortalEntities db = new PortalEntities();
            var request = (from rr in db.Requests
                           where rr.id == id
                           select rr).FirstOrDefault();
            return View(request);
        }

        [HttpPost]
        [ActionName("DeleteRequest")]
        public ActionResult DeleteRequests(int id)
        {
            PortalEntities db = new PortalEntities();
            var request = (from rr in db.Requests
                           where rr.id == id
                           select rr).FirstOrDefault();
            db.Requests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("CheckRequests");
        }

        public ActionResult ProfileChange()
        {
            PortalEntities db = new PortalEntities();
            var id = Convert.ToInt32(Session["id"]);
            var user = db.Users.FirstOrDefault(e => e.userid == id);
            return View(user);
        }

        public ActionResult UpdateProfile(int id)
        {
            PortalEntities db = new PortalEntities();
            var user = (from u in db.Users
                        where u.userid == id
                        select u).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateProfile(User u)
        {

            PortalEntities db = new PortalEntities();
            var user = (from uu in db.Users
                        where uu.userid == u.userid
                        select uu).FirstOrDefault();

            user.uid= u.uid;
            user.name = u.name;
            user.email = u.email;
            user.password = u.password;

            db.SaveChanges();
            return RedirectToAction("ProfileChange");
        }

    }

} 