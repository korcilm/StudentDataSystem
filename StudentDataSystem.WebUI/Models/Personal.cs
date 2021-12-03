using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataSystem.WebUI.Models
{
    public class Personal
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string BloodType { get; set; }
        public DateTime BirthDate { get; set; }
        public string HesCode { get; set; }
    }
}
