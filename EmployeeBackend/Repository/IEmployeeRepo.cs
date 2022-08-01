using EmployeeBackend.DTOs;
using EmployeeBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBackend.Repository
{
    internal interface IEmployeeRepo
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(string Id);

        Employee PostEmployee(EmployeeRequestDto Dto);
        int UpdateEmployee(EmployeeRequestDto Dto);
        int DeleteEmployee(string Id);
    }
}
