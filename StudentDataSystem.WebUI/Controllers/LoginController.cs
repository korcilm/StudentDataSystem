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
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Personal model)
        {
            if (model != null)
            {
                Personal personal = new Personal();
                personal.Address = model.Address;
                personal.Password = model.Password;
                personal.BirthDate = model.BirthDate;
                personal.BloodType = model.BloodType;
                personal.Department = model.Department;
                personal.Email = model.Email;
                personal.HesCode = model.HesCode;
                personal.IdentityNumber = model.IdentityNumber;
                personal.Name = model.Name;
                personal.PhoneNumber = model.PhoneNumber;
                personal.Surname = model.Surname;
                personal.RoleId = 1;
                _context.Personals.Add(personal);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
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
                            return RedirectToAction("Index","Student", new { id = item.Id });
                        }
                       
                    }
                }
                if (personals != null)
                {
                    foreach (var item in personals)
                    {
                        if (item.IdentityNumber == signInViewModel.IdentityNumber && item.Password == signInViewModel.Password)
                        {
                            return RedirectToAction("Index", "Personal",new { id = item.Id });
                        }

                    }
                }

            }
            return View();
        }
    }
}
