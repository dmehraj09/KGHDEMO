using ServiceStack;
using ServiceStack.Web;
using EmployeeBackend.DTOs;
using EmployeeBackend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using EmployeeBackend.Repository;

namespace EmployeeBackend.Services
{
    
    public class EmployeeService : Service
    {
        private readonly IEmployeeRepo repository;

        public EmployeeService()
        {
            this.repository = new EmployeeRepo();
        }      


        public IHttpResult Get(EmployeeRequestDto Dto)        
        {
            if (Dto.Id == default(int))
            {
                var result = new HttpResult(repository.GetEmployees());
                return result;
            }
            else
            {
                var emp = repository.GetEmployee(Dto.Id.ToString());

                if (emp != null)
                {
                    return new HttpResult(emp);
                }
                else
                {
                    return new HttpError(HttpStatusCode.NotFound,"employee with id "+ Dto.Id + " doesn't exist.");
                }
            }
        }

        public object Post(EmployeeRequestDto dto)
        {
            var result = new HttpResult(repository.PostEmployee(dto));
            return result;
        }

        public object Put(EmployeeRequestDto dto)
        {
            var result = new HttpResult(repository.UpdateEmployee(dto));
            return result;
        }

        public object Delete(EmployeeRequestDto dto)
        {
            var result = new HttpResult(repository.DeleteEmployee(dto.Id.ToString()));
            return result;
        }
    }    

}