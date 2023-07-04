using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCPractical13_2.Models
{
    public class EmployeeDesignationDBContext: DbContext
    {
        public EmployeeDesignationDBContext(): base("name=DBCS") { }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<DesignationModel> Designations { get; set; }
    }
}