using Backend.ServiceInterface.Models;
using Backend.ServiceModel;
using Backend.Repository;
using System.Collections.Generic;
using System.Linq;
using Backend.ServiceInterface.Converters;

namespace Backend.ServiceInterface.service
{

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo empRepo;  
        //private readonly IRepository<Employee> empRepo;


        public EmployeeService(IEmployeeRepo repo)
        {
            
            empRepo = repo;
        }

        public EmployeeResonseDto GetEmployees()
        {
            
                    EmployeeResonseDto employeeResonseDto = new EmployeeResonseDto();
                    IEnumerable<Employee> obj = Enumerable.Empty<Employee>();
                    obj = empRepo.GetEmployees();
                    List<EmployeeRequestDto> employeeRequestDtos = obj.Select(x => new EmployeeRequestDto
                    {
                        Id = x.Id,
                        Designation = x.Designation,
                        Address = x.Address,
                        Mobile = x.Mobile,
                        Name = x.Name,
                    }).ToList();
                    employeeResonseDto.Employees = employeeRequestDtos;                    
                    return employeeResonseDto;
        }



        public void PostEmployee(EmployeeRequestDto dto)
        {            
            empRepo.PostEmployee(Converter.ConvertEmployeeRequestDtoToEmployee(dto));              

        }

        

        public void UpdateEmployee(EmployeeRequestDto dto)
        {
              empRepo.UpdateEmployee(Converter.ConvertEmployeeRequestDtoToEmployee(dto));
                
        }

        public void DeleteEmployee(EmployeeRequestDto dto)
        {
            
             empRepo.DeleteEmployee(Converter.ConvertEmployeeRequestDtoToEmployee(dto));              

        }

       
    }
}
