using Backend.ServiceInterface.service;
using Backend.ServiceModel;
using ServiceStack;
using ServiceStack.Web;
using System.Net;

namespace Backend.ServiceInterface.Services
{

    public class EmployeeAPI : Service
    {
        private readonly IEmployeeService _service;

        public EmployeeAPI(IEmployeeService service)
        {
            this._service = service;
        }      


        public EmployeeResonseDto Get(EmployeeRequestDto dto)        
        {            
            
                var result = _service.GetEmployees();
                return result;
           
            
        }

        public void Post(EmployeeRequestDto dto)
        {
            _service.PostEmployee(dto);
            
        }

        public void Put(EmployeeRequestDto dto)
        {
            _service.UpdateEmployee(dto);            
        }

        public void Delete(EmployeeRequestDto dto)
        {
            _service.DeleteEmployee(dto);
           
        }
    }    

}