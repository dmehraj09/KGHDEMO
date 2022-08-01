using Backend.ServiceModel;
using Backend.ServiceInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBackend.Repository
{
    internal interface IEmployeeRepo
    {
        IEnumerable<Backend.ServiceInterface.Models.Employee> GetEmployees();
        Backend.ServiceInterface.Models.Employee GetEmployee(string Id);

        Backend.ServiceInterface.Models.Employee PostEmployee(EmployeeRequestDto Dto);
        int UpdateEmployee(EmployeeRequestDto Dto);
        int DeleteEmployee(string Id);
    }
}
