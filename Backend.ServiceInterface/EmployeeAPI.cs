using Backend.ServiceInterface.service;
using Backend.ServiceModel;
using ServiceStack;
using ServiceStack.Web;
using System.Net;

namespace Backend.ServiceInterface.Services
{

    public class EmployeeAPI : Service
    {
        private readonly IEmployeeService service;

        public EmployeeAPI(IEmployeeService service)
        {
            this.service = service;
        }      


        public EmployeeResonseDto Get(EmployeeRequestDto Dto)        
        {            
            
                var result = service.GetEmployees();
                return result;
           
            
        }

        public int Post(EmployeeRequestDto dto)
        {
            var result = service.PostEmployee(dto);
            return result;
        }

        public int Put(EmployeeRequestDto dto)
        {
            var result = service.UpdateEmployee(dto);
            return result;
        }

        public int Delete(EmployeeRequestDto dto)
        {
            var result = service.DeleteEmployee(dto);
            return result;
        }
    }    

}