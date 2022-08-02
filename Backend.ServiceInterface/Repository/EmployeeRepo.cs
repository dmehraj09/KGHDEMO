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

        public int PostEmployee(Employee _postObj)
        {
            employeeRep.Insert(_postObj);
            return 1;
            
        }

        public int UpdateEmployee(Employee Dto)
        {
            employeeRep.Update(Dto);
            return 1;

        }

        public int DeleteEmployee(Employee Dto)
        {
            employeeRep.Delete(Dto);
            return 1;
        }        
    }
}