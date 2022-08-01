using Funq;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.Razor;
using EmployeeBackend.Models;
using EmployeeBackend.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EmployeeBackend.Startup
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("Employee Service", typeof(EmployeeService).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;
            Plugins.Add(new RazorFormat());
          
            Database.SetInitializer<EmployeeContext>
                (new DropCreateDatabaseIfModelChanges<EmployeeContext>());            
        }
    }
}