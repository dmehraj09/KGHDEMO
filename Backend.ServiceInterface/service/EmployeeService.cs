using Backend.ServiceInterface.Models;
using Backend.ServiceModel;
using Backend.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Backend.ServiceInterface.service
{
    
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo repository;

        public EmployeeService(IEmployeeRepo rep)
        {
            this.repository = rep;
        }       

        public EmployeeResonseDto GetEmployees()
        {
            EmployeeResonseDto employeeResonseDto = new EmployeeResonseDto();
            IEnumerable <Employee>  obj = Enumerable.Empty<Employee>();            
            obj =  repository.GetEmployees();     
            employeeResonseDto.Employees = obj.Select(x => new EmployeeRequestDto
            {
                Id = x.Id,
                Designation = x.Designation,
                Address = x.Address,
                Mobile = x.Mobile,
                Name = x.Name,
            });
            return employeeResonseDto;
        }


        public int PostEmployee(EmployeeRequestDto Dto)
        {
            Employee _postobj = new Employee
            {
                Address = Dto.Address,
                Designation = Dto.Designation,
                Name = Dto.Name,
                Mobile = Dto.Mobile
            };
          return repository.PostEmployee(_postobj);

                     

        }

        public int UpdateEmployee(EmployeeRequestDto Dto)
        {
            Employee _postobj = new Employee
            {
                Id = Dto.Id,
                Address = Dto.Address,
                Designation = Dto.Designation,
                Name = Dto.Name,
                Mobile = Dto.Mobile
            };
            return repository.UpdateEmployee(_postobj);
        }

        public int DeleteEmployee(EmployeeRequestDto Dto)
        {
            Employee _postobj = new Employee
            {
                Id = Dto.Id,
                Address = Dto.Address,
                Designation = Dto.Designation,
                Name = Dto.Name,
                Mobile = Dto.Mobile
            };
            return repository.DeleteEmployee(_postobj);
        }
    }
}
