using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPractical11_2.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field can't be empty.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="This field can't be empty.")]
        [DataType(DataType.Date)]
        [Display(Name="Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public string DOB { get; set; }

        [Required(ErrorMessage ="This field can't be empty.")]
        public string Address { get; set; }
    }
}