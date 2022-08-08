using Backend.ServiceInterface.Models;
using Backend.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ServiceInterface.Converters
{
    public class Converter
    {
        public static Employee ConvertEmployeeRequestDtoToEmployee(EmployeeRequestDto dto)
        {
            return new Employee
            {
                Id = dto.Id,
                Address = dto.Address,
                Designation = dto.Designation,
                Name = dto.Name,
                Mobile = dto.Mobile
            };
        }
    }
}
