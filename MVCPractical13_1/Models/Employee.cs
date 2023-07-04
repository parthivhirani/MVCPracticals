using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPractical13_1.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Name can't be empty")]
        [StringLength(50, ErrorMessage ="Maximum 50 characters are allowed ")]
        public string Name { get; set; }


        [Required(ErrorMessage ="Date of Birth can't be null")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public string DOB { get; set; }


        public int Age { get; set; }
    }
}