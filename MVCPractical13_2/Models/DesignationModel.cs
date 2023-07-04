using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPractical13_2.Models
{
    public class DesignationModel
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(50, ErrorMessage ="Maximum length is 50")]
        public string Designation { get; set; }


        public ICollection<EmployeeModel> Employees { get; set; }
    }
}