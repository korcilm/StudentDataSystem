using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataSystem.WebUI.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int PersonalId { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public double Midterm { get; set; }
        public double Final { get; set; }
        public Lesson Lesson { get; set; }
        public Student Student { get; set; }
        public Personal Personal { get; set; }
    }
}
