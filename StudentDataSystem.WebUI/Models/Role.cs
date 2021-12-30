using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataSystem.WebUI.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public Student Student { get; set; }
        public Personal Personal { get; set; }

    }
}
