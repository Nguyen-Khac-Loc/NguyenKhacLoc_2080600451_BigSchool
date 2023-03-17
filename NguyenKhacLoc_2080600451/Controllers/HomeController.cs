using NguyenKhacLoc_2080600451.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenKhacLoc_2080600451.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;
        public HomeController() 
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingCourses = context.Courses.Include(c => c.Lecturer).Include(c => c.Category).Where(c => c.DateTime > DateTime.Now);
            return View(upcomingCourses);
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
    }
}