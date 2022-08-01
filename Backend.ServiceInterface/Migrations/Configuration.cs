namespace Backend.ServiceInterface.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Backend.ServiceInterface.Models.EmployeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Backend.ServiceInterface.Models.EmployeeContext context)
        {
            context.Employees.AddOrUpdate(x => x.Id,
            new Models.Employee() { Id = 1, Name = "Jane Austen", Address = "Sopore", Designation = "TL", Mobile = "90988" },
            new Models.Employee() { Id = 2, Name = "Charles Dickens", Address = "Sopore", Designation = "TL", Mobile = "90988" },
            new Models.Employee() { Id = 3, Name = "Miguel de Cervantes", Address = "Sopore", Designation = "TL", Mobile = "90988" }
        );
        }
    }
}
