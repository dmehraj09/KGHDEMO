using Backend.ServiceInterface.Models;
using Backend.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ServiceInterface.service
{
    public interface IEmployeeService
    {
        EmployeeResonseDto GetEmployees();
        int PostEmployee(EmployeeRequestDto Dto);

        int UpdateEmployee(EmployeeRequestDto Dto);

        int DeleteEmployee(EmployeeRequestDto Dto);

    }
}
