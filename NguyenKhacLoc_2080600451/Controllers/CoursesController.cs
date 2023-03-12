using Microsoft.AspNet.Identity;
using NguyenKhacLoc_2080600451.Models;
using NguyenKhacLoc_2080600451.ViewModels;
using System;
using System.Collections.Generic;
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
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
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
    }
}
