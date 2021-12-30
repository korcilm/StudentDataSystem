using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDataSystem.WebUI.DataAccess;
using StudentDataSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataSystem.WebUI.Controllers
{
    public class StudentController : Controller
    {


        private readonly StudentDataSystemContext _context;
        public StudentController(StudentDataSystemContext context)
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
                if (item.StudentId == id)
                {
                    GradeListViewModel gradeOne = new GradeListViewModel();
                    student = _context.Set<Student>().Where(x => x.Id == item.StudentId).FirstOrDefault();
                    personal = _context.Set<Personal>().Where(x => x.Id == item.PersonalId).FirstOrDefault();
                    lesson = _context.Set<Lesson>().Where(x => x.Id == item.LessonId).FirstOrDefault();
                    gradeOne.StudentName = student.Name + " " + student.Surname;
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
        public IActionResult AddStudent()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student model)
        {

            if (model != null)
            {
                Student student = new Student();
                student.Address = model.Address;
                student.Password = model.Password;
                student.BirthDate = model.BirthDate;
                student.BloodType = model.BloodType;
                student.Department = model.Department;
                student.Email = model.Email;
                student.HesCode = model.HesCode;
                student.IdentityNumber = model.IdentityNumber;
                student.Name = model.Name;
                student.PhoneNumber = model.PhoneNumber;
                student.StudentNumber = model.StudentNumber;
                student.Surname = model.Surname;
                _context.Students.Add(student);
                _context.SaveChanges();
            }
            return View();
        }
        public IActionResult DeleteStudent(int id)
        {
            _context.Set<Student>().Remove(new Student { Id = id });
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult UpdateStudent(int id)
        {
            Student students = new Student();
            students = _context.Set<Student>().Where(x => x.Id == id).FirstOrDefault();
            return View(students);
        }
        [HttpPost]
        public IActionResult UpdateStudent(Student model)
        {
            if (model != null)
            {
                Student student = new Student();
                student.Address = model.Address;
                student.Id = model.Id;
                student.BirthDate = model.BirthDate;
                student.BloodType = model.BloodType;
                student.Department = model.Department;
                student.Email = model.Email;
                student.HesCode = model.HesCode;
                student.IdentityNumber = model.IdentityNumber;
                student.Name = model.Name;
                student.Password = model.Password;
                student.PhoneNumber = model.PhoneNumber;
                student.StudentNumber = model.StudentNumber;
                student.Surname = model.Surname;
                _context.Students.Update(student);
                _context.SaveChanges();
            }


            return View();
        }
    }
}
