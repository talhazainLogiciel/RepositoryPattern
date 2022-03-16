using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;
        private readonly IStudent _student;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(IStudent student)
        {
           _student = student;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var students = _student.GetAll();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create ()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Insert(Student student)
        {
            _student.Insert(student);
            //_student.Save();
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _student.GetByStudentID(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            _student.Delete(student);
            //_student.Save();
            return View(student);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
            var student = _student.GetByStudentID(id);

            return View(student);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _student.GetByStudentID(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _student.Update(student);
            //_student.Save();
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
