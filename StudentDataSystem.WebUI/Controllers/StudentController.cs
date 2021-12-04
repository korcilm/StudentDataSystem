using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataSystem.WebUI.Controllers
{
    public class StudentController:Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult AddStudent()
        {

            return View();
        }
    }
}
