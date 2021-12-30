using Microsoft.AspNetCore.Mvc;
using StudentDataSystem.WebUI.DataAccess;
using StudentDataSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataSystem.WebUI.Controllers
{
    public class PersonalController : Controller
    {
        private readonly StudentDataSystemContext _context;
        public PersonalController(StudentDataSystemContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            Personal personal = new Personal();
            List<Grade> grades = new List<Grade>();
            List<Lesson> lessons = new List<Lesson>();
            Lesson lesson = new Lesson();
            personal = _context.Set<Personal>().Where(x => x.Id == id).FirstOrDefault();
            grades = _context.Set<Grade>().ToList();
            foreach (var item in grades)
            {
                if (item.PersonalId == id)
                {
                    lesson = _context.Set<Lesson>().Where(x => x.Id == item.LessonId).FirstOrDefault();
                    if (!lessons.Contains(lesson))
                    {
                        lessons.Add(lesson);
                    };
                    
                }
            }

            return View(lessons);

        }


    }
}
