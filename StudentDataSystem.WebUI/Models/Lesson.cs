using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataSystem.WebUI.Models
{
    public class Lesson
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public List<Grade> Grades { get; set; }
    }
}
