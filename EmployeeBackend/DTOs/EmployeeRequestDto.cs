using ServiceStack;
using EmployeeBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeBackend.DTOs
{
    [Route("/employees", Verbs = "GET, POST")] 
    [Route("/employees/{Id}", Verbs = "GET, PUT,DELETE")]    
    public class EmployeeRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Designation { get; set; }
    }
}