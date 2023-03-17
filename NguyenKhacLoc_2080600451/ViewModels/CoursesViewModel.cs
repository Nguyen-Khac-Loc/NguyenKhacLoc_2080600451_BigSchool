using NguyenKhacLoc_2080600451.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NguyenKhacLoc_2080600451.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcomingCourses { get; set; }
        public bool ShowAction { get; set; }
       
    }
}