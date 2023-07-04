using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPractical13_2.Models
{
    public class Query1
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string DOB { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
    }
}