using Microsoft.AspNetCore.Mvc;
using StudentDataSystem.WebUI.DataAccess;
using StudentDataSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataSystem.WebUI.Controllers
{
    public class PersonalController:Controller
    {
        private readonly StudentDataSystemContext _context;
        public PersonalController(StudentDataSystemContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Personal> personals = new List<Personal>();
            personals = _context.Set<Personal>().ToList();
            if (personals != null)
            {
                return View(personals);
            }
            else
            {
                return View();
            }
        }
        public IActionResult AddPersonal(Personal model)
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
                _context.Personals.Add(personal);
                _context.SaveChanges();
            }
            return View();
        }

    }
}
