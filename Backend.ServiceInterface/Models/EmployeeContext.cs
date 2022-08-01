using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Backend.ServiceInterface.Models
{
    public class EmployeeContext : DbContext
    {
        // Database Instance Name

        public EmployeeContext()
            : base("EmployeeDB")
        { }

        public DbSet<Employee> Employees { get; set; }
    }
}


