using Funq;
using ServiceStack;
using Backend.ServiceInterface;
using System.Data.Entity;
using Backend.ServiceInterface.context;
using Backend.ServiceInterface.service;
using Backend.ServiceInterface.Repository;
using Backend.Repository;
using Backend.ServiceInterface.Models;

[assembly: HostingStartup(typeof(Backend.AppHost))]

namespace Backend;

public class AppHost : AppHostBase, IHostingStartup
{

    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(services => {
            // Configure ASP.NET Core IOC Dependencies
        }        
        );

    public AppHost() : base("Backend", typeof(MyServices).Assembly) {}


    
    public override void Configure(Container container)
    {
        // enable server-side rendering, see: https://sharpscript.net/docs/sharp-pages
        Plugins.Add(new SharpPagesFeature {
            EnableSpaFallback = true
        });

        

        Database.SetInitializer<EmployeeContext>
            (new CreateDatabaseIfNotExists<EmployeeContext>());
        container.RegisterAs<Backend.ServiceInterface.Repository.Repository<Employee>, Backend.ServiceInterface.Repository.IRepository<Employee>>();
        container.RegisterAs<EmployeeRepo, IEmployeeRepo>();
        container.RegisterAs<EmployeeService, IEmployeeService>();
        SetConfig(new HostConfig {
            AddRedirectParamsToQueryString = true,
        });
    }
}
