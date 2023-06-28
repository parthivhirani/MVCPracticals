using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPractical10.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public Nullable<int> Salary { get; set; }
        public Nullable<int> Age { get; set; }
        public string City { get; set; }
    }
}