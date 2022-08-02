using Backend.ServiceInterface.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ServiceInterface.Mapping
{
    internal class EmployeeMap: EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            //key  
            HasKey(t => t.Id);
            //properties  
            Property(t => t.Address);
            Property(t => t.Designation);
            Property(t => t.Mobile);
            Property(t => t.Name);
            Property(t => t.AddedDate);
            Property(t => t.ModifiedDate);
            //table  
            ToTable("Employees");
        }
    }
}
