using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Controllers
{
    [Authorize]
    public class FecultyController : Controller
    {
        // GET: Course

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index()
        {
            PortalEntities db = new PortalEntities();
             var courses = db.Courses.ToList();
                return View(courses);

             
        }

        [HttpPost]
        public ActionResult Index(string searchCourse)
        {
            PortalEntities db = new PortalEntities();
            var course = (from c in db.Courses
                         where c.name.Contains(searchCourse)
                         select c).ToList();
            return View(course);
        }

        public ActionResult Details(int Id)
        {
            PortalEntities db = new PortalEntities();
            
                var cour = (from c in db.Courses
                            where c.id == Id
                            select c).FirstOrDefault();

                return View(cour);
        }

        public ActionResult AllStudents()
        {
             PortalEntities db = new PortalEntities();
           
             
                var students = (from u in db.Users
                                where u.type == "Student"
                                select u).ToList();
                return View(students); 
        }

        public ActionResult AddGrade()
        {
            Mark m = new Mark();
            return View(m);
        }

        [HttpPost]
        public ActionResult AddGrade(Mark m)
        {
            var id = Convert.ToInt32(Session["Id"]);

            if (ModelState.IsValid)
            {
                PortalEntities db = new PortalEntities();
                Mark mk = new Mark();
                mk.userid = id;
                mk.coursename = m.coursename;
                mk.department = m.department;
                mk.grade = m.grade;
                
                db.Marks.Add(mk);
                db.SaveChanges();
                return RedirectToAction("CheckGrade");
            }

            return View(m);

        }

        public ActionResult CheckGrade()
        {
            PortalEntities db = new PortalEntities();
            var marks = db.Marks.ToList();
            return View(marks);
        }

        [HttpPost]
        public ActionResult CheckGrade(string searchGrade)
        {
            PortalEntities db = new PortalEntities();
            var grade = (from g in db.Marks
                          where g.coursename.Contains(searchGrade)
                          select g).ToList();
            return View(grade);
        }

        public ActionResult CheckGradeDetails(int id)
        {

            PortalEntities db = new PortalEntities();

            var user = (from m in db.Users
                        where m.userid == id
                        select m).FirstOrDefault();

            return View(user);
        }

        public ActionResult EditGrade(int id)
        {
            PortalEntities db = new PortalEntities();
            var grade = (from g in db.Marks
                         where g.id == id
                         select g).FirstOrDefault();
            return View(grade);
        }
        [HttpPost]
        public ActionResult EditGrade(Mark m)
        {
            PortalEntities db = new PortalEntities();
            var grades = (from gd in db.Marks
                         where gd.id == m.id
                         select gd).FirstOrDefault();
           
            grades.coursename = m.coursename;
            grades.department = m.department;
            grades.grade = m.grade;
            db.SaveChanges();
            return RedirectToAction("CheckGrade");
        }

        public ActionResult DeleteGrade(int id)
        {
            PortalEntities db = new PortalEntities();
            var graded = (from dg in db.Marks
                         where dg.id == id
                         select dg).FirstOrDefault();
            return View(graded);
        }

        [HttpPost]
        public ActionResult DeleteGrade(Mark md)
        {
            using (PortalEntities db = new PortalEntities())
                {
                var gradeds = (from dg in db.Marks
                               where dg.id == md.id
                               select dg).FirstOrDefault();
                db.Marks.Remove(gradeds);
                db.SaveChanges();
                return RedirectToAction("CheckGrade");
            }
        }



        public ActionResult CreateNotice()
        {
            Notice n = new Notice();
            n.userid = Convert.ToInt32(Session["id"]);
            n.createdat = DateTime.Now;
            n.updateinfo = "New Notice";
          
            return View(n);

        }

        [HttpPost]
        public ActionResult CreateNotice(Notice n)
        {
            if (ModelState.IsValid)
            {
                PortalEntities db = new PortalEntities();
                db.Notices.Add(n);
                db.SaveChanges();
                return RedirectToAction("CheckNotice");
            }
            return View();
        }

        public ActionResult CheckNotice()
        {
            PortalEntities db = new PortalEntities();
            var notice = db.Notices.ToList();
            return View(notice);
        }

        [HttpPost]
        public ActionResult CheckNotice(string searchnotice)
        {
            PortalEntities db = new PortalEntities();
            var notice = (from g in db.Notices
                         where g.notice1.Contains(searchnotice)
                         select g).ToList();
            return View(notice);
        }


        public ActionResult EditNotice(int id)
        {
            PortalEntities db = new PortalEntities();
            var not = (from n in db.Notices
                         where n.noticeid == id
                         select n).FirstOrDefault();
            return View(not);
        }
        [HttpPost]
        public ActionResult EditNotice(Notice m)
        {
            PortalEntities db = new PortalEntities();
            var nots = (from nt in db.Notices
                          where nt.noticeid == m.noticeid
                          select nt).FirstOrDefault();

            nots.usertype = m.usertype;
            nots.notice1 = m.notice1;
            nots.status = m.status;
            nots.updateinfo = "Updated";
            db.SaveChanges();
            return RedirectToAction("CheckNotice");
        }

        public ActionResult DeleteNotice(int id)
        {
            PortalEntities db = new PortalEntities();
            var notice =(from dn in db.Notices
                         where dn.noticeid == id
                        select dn).FirstOrDefault();
            return View(notice);
        }

        [HttpPost]
        [ActionName("DeleteNotice")]
        public ActionResult DeleteNotices(int id)
        {
            PortalEntities db = new PortalEntities();
            var notice = (from dn in db.Notices
                          where dn.noticeid == id
                          select dn).FirstOrDefault();
            db.Notices.Remove(notice);
            db.SaveChanges();
            return RedirectToAction("CheckNotice");
        }

        public ActionResult AllStudentsDetails()
        {
            PortalEntities db = new PortalEntities();

            var students = (from u in db.Users
                            where u.type == "Student"
                            select u).ToList();
            return View(students);
        }

        [HttpPost]
        public ActionResult AllStudentsDetails(string searchuser)
        {
            PortalEntities db = new PortalEntities();
            var students = (from u in db.Users
                          where u.name.Contains(searchuser)
                          select u).ToList();
            return View(students);
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
            var user = (from gd in db.Users
                          where gd.userid == u.userid
                          select gd).FirstOrDefault();

            user.name = u.name;
            user.email = u.email;
            user.password = u.password;
            db.SaveChanges();
            return RedirectToAction("ProfileChange");
        }



    }
}
