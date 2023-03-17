using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using NguyenKhacLoc_2080600451.Models;
using NguyenKhacLoc_2080600451.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenKhacLoc_2080600451.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Courses
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _context.Categories.ToList()
            };
            
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                CategoryId = viewModel.Category,
                DateTime = viewModel.GetDateTime(),
                Place = viewModel.Place
            };
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var course = _context.Attendances
                .Where(a=>a.AttendeeId == userId)
                .Select(a=>a.Course)
                .Include(l=>l.Lecturer)
                .Include (l=>l.Category)
                .ToList();
            var viewModel = new CoursesViewModel
            {
                UpcomingCourses = course,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }
        [Authorize]
        public ActionResult Following()
        {
            return RedirectToAction("Index", "Home");
            
        }
    }
}
