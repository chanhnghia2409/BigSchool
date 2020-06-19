using BigSchool.Models;
using BigSchool.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        
        private readonly Models.ApplicationDbContext _dbContext;

        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Create()
        {
            var viewModel = new CourseModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }
        // GET: Courses
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize] 
        public ActionResult Create(CourseModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
            };
            return View("Create",viewModel);
            var Course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                CategoryId = viewModel.Category,
                datetime = viewModel.GetDateTime(),
                Place = viewModel.Place,
                
            };
            _dbContext.Courses.Add(Course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}