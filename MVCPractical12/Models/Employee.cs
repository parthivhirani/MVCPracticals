﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPractical12.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Display(Name ="Date of Birth")]
        public DateTime DOB { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string Address { get; set; }
    }
}