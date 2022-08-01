using Backend.ServiceModel;
using Backend.ServiceInterface.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EmployeeBackend.Repository
{
    internal class EmployeeRepo : IEmployeeRepo
    {
        //private EmployeeContext db = new EmployeeContext();

        private readonly EmployeeContext _context;
        public EmployeeRepo()
        {
            _context = new EmployeeContext();
        }
        public EmployeeRepo(EmployeeContext context)
        {
            _context = context;
        }



        public Backend.ServiceInterface.Models.Employee GetEmployee(string Id)
        {
            Backend.ServiceInterface.Models.Employee emp = _context.Employees.Where(x => x.Id.ToString() == Id).FirstOrDefault();
            return emp;
        }

        public IEnumerable<Backend.ServiceInterface.Models.Employee> GetEmployees()
        {
            return _context.Employees.ToList();
            
        }

        public Backend.ServiceInterface.Models.Employee PostEmployee(EmployeeRequestDto Dto)
        {
            Backend.ServiceInterface.Models.Employee newObj = new Backend.ServiceInterface.Models.Employee {
                                            Address = Dto.Address,
                                            Designation = Dto.Designation,
                                            Name = Dto.Name,
                                            Mobile = Dto.Mobile };
            _context.Employees.Add(newObj);
            _context.SaveChanges();
            return newObj;

        }

        public int UpdateEmployee(EmployeeRequestDto Dto)
        {
            Backend.ServiceInterface.Models.Employee newObj = _context.Employees.Where(x => x.Id == Dto.Id).FirstOrDefault();
            if (newObj != null)
            {
                newObj.Name = Dto.Name;
                newObj.Address = Dto.Address;
                newObj.Designation = Dto.Designation;
                newObj.Mobile = Dto.Mobile;
                return _context.SaveChanges();
            }
            else
            {
                return 0;
            }           

        }

        public int DeleteEmployee(string Id)
        {
            Backend.ServiceInterface.Models.Employee newObj = _context.Employees.Where(x => x.Id.ToString() == Id).FirstOrDefault();
            if (newObj != null)
            {
                _context.Employees.Remove(newObj);
               return _context.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}