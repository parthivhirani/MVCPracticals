using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractical11_1.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public string DOB { get; set; }

        [Required]
        public string Address { get; set; }
    }
}