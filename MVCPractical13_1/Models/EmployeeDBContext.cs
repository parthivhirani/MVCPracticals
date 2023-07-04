using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCPractical13_1.Models
{
    public class EmployeeDBContext: DbContext
    {
        public EmployeeDBContext() : base("name=DBCS") { }

        public DbSet<Employee> Employees { get; set; }
    }
}