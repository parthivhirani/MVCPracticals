using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCPractical13_2.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string FirstName { get; set; }


        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string MiddleName { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string LastName { get; set; }


        [Required]
        public string DOB { get; set; }


        [Required]
        [StringLength(10, ErrorMessage = "Maximum length is 10")]
        public string MobileNumber { get; set; }


        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        public string Address { get; set; }


        [Required]
        public double Salary { get; set; }

        [ForeignKey("Designation")]
        public int DesignationId { get; set; }
        public DesignationModel Designation { get; set; }

    }
}