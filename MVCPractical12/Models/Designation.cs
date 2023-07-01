using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPractical12.Models
{
    public class Designation
    {
        public int Id { get; set; }
        [Required]
        public string DesignationName { get; set; }

        public ICollection<Employee3> EmployeeDetails { get; set; }
    }
}