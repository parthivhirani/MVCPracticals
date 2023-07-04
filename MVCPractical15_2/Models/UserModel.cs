using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPractical15_2.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "User name can't be empty.")]
        public string UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}