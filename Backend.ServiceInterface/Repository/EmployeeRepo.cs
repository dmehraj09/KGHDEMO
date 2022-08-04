using System;
using System.Collections.Generic;
using System.Linq;
using Backend.ServiceInterface.context;
using Backend.ServiceInterface.Models;
using Backend.ServiceInterface.Repository;

namespace Backend.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        //private EmployeeContext db = new EmployeeContext();
        private readonly IRepository<Employee> employeeRep;
        
        public EmployeeRepo(IRepository<Employee> employeeRepository)
        {
            this.employeeRep = employeeRepository; 
        }

        

        public IEnumerable<Employee> GetEmployees()
        {
            return employeeRep.Get();
            
        }

        public void PostEmployee(Employee postObj)
        {
            employeeRep.Insert(postObj);           
            
        }

        public void UpdateEmployee(Employee dto)
        {
            employeeRep.Update(dto);
            

        }

        public void DeleteEmployee(Employee dto)
        {
            employeeRep.Delete(dto);           
        }        
    }
}