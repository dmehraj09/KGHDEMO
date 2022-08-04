using Backend.ServiceInterface.Models;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> GetEmployees();      

        void PostEmployee(Employee postObj);
        void UpdateEmployee(Employee dto);
        void DeleteEmployee(Employee dto);
    }
}
