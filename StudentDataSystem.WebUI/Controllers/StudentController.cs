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
        public IActionResult Index()
        {

            List<Student> students = new List<Student>();
            students = _context.Set<Student>().ToList();
            if (students != null)
            {
                return View(students);
            }
            else
            {
                return View();
            }
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
