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
            try
            {
                return employeeRep.Get();
            }
            catch (System.Exception ex)
            {                
                throw;
            }

        }

        public void PostEmployee(Employee postObj)
        {
            employeeRep.CreateTransaction();
            try
            {
                employeeRep.Insert(postObj);
                employeeRep.Save();
                employeeRep.Commit();
            }
            catch (System.Exception ex)
            {
                employeeRep.Rollback();
            }

        }

        public void UpdateEmployee(Employee postObj)
        {
            employeeRep.CreateTransaction();
            try
            {
                employeeRep.Update(postObj);
                employeeRep.Save();
                employeeRep.Commit();
            }
            catch (System.Exception ex)
            {
                employeeRep.Rollback();
            }


        }

        public void DeleteEmployee(Employee postObj)
        {
            employeeRep.CreateTransaction();
            try
            {
                employeeRep.Delete(postObj);
                employeeRep.Save();
                employeeRep.Commit();
            }
            catch (System.Exception ex)
            {
                employeeRep.Rollback();
            }
        }        
    }
}