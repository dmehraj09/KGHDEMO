﻿using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Backend.ServiceInterface.Models
{
    public class Employee
    {
        [AutoIncrement]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Designation { get; set; }
    }
}