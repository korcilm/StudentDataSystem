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

    }
}
