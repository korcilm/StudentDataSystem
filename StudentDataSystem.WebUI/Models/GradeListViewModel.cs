using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataSystem.WebUI.Models
{
    public class GradeListViewModel
    {
        public int Id { get; set; }
        public string PersonalName { get; set; }
        public string StudentName { get; set; }
        public string LessonName { get; set; }
        public double Midterm { get; set; }
        public double Final { get; set; }
    }
}
