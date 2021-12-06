using Microsoft.AspNetCore.Mvc;
using StudentDataSystem.WebUI.DataAccess;
using StudentDataSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataSystem.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly StudentDataSystemContext _context;

        public LoginController(StudentDataSystemContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult SignIn(SignInViewModel signInViewModel)
        {

            List<Student> students = new List<Student>();
            students = _context.Set<Student>().ToList();

            List<Personal> personals = new List<Personal>();
            personals = _context.Set<Personal>().ToList();



            if (signInViewModel!=null)
            {
                if(students!=null)
                {
                    foreach (var item in students)
                    {
                        if(item.IdentityNumber == signInViewModel.IdentityNumber && item.Password == signInViewModel.Password)
                        {
                            return RedirectToAction("Index","Home");
                        }
                       
                    }
                }
                if (personals != null)
                {
                    foreach (var item in personals)
                    {
                        if (item.IdentityNumber == signInViewModel.IdentityNumber && item.Password == signInViewModel.Password)
                        {
                            return RedirectToAction("Index", "Home");
                        }

                    }
                }

            }
            return View();
        }
    }
}
