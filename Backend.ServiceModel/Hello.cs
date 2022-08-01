using ServiceStack;

namespace Backend.ServiceModel
{
    [Route("/employees", Verbs = "GET, POST")]
    [Route("/employees/{Id}", Verbs = "GET, PUT,DELETE")]
    public class EmployeeRequestDto : IReturn<EmployeeResonseDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Designation { get; set; }
    }

    public class EmployeeResonseDto 
    {
        public System.Collections.Generic.IEnumerable<Employee> Employees { get; set; }
       
    }
    public class Employee
    {       
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Designation { get; set; }
    }

    [Route("/hello")]
    [Route("/hello/{Name}")]
    public class Hello : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public string Result { get; set; }
    }
}
