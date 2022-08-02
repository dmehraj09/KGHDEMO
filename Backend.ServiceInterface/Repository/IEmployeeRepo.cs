using Backend.ServiceInterface.Models;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> GetEmployees();      

        int PostEmployee(Employee _postObj);
        int UpdateEmployee(Employee Dto);
        int DeleteEmployee(Employee Dto);
    }
}
