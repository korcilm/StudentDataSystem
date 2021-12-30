using Microsoft.AspNetCore.Mvc;
using StudentDataSystem.WebUI.DataAccess;
using StudentDataSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataSystem.WebUI.Controllers
{
    public class GradeController : Controller
    {
        private readonly StudentDataSystemContext _context;
        public GradeController(StudentDataSystemContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            List<Grade> grades = new List<Grade>();
            List<GradeListViewModel> gradeList = new List<GradeListViewModel>();
            Student student = new Student();
            Lesson lesson = new Lesson();
            Personal personal = new Personal();
            grades = _context.Set<Grade>().ToList();
            foreach (var item in grades)
            {
                if (item.LessonId==id)
                {
                    GradeListViewModel gradeOne = new GradeListViewModel();
                    student = _context.Set<Student>().Where(x => x.Id == item.StudentId).FirstOrDefault();
                    personal = _context.Set<Personal>().Where(x => x.Id == item.PersonalId).FirstOrDefault();
                    lesson = _context.Set<Lesson>().Where(x => x.Id == item.LessonId).FirstOrDefault();
                    gradeOne.StudentName = student.Name +" "+student.Surname;
                    gradeOne.Midterm = item.Midterm;
                    gradeOne.Final = item.Final;
                    gradeOne.LessonName = lesson.Name;
                    gradeOne.Id = item.Id;
                    gradeOne.PersonalName = personal.Name + " " + personal.Surname;
                    gradeList.Add(gradeOne);
                }
                
            }
            return View(gradeList);
        }
    }
}
