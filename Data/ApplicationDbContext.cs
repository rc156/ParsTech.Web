using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ParsTech.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParsTech.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
      

        //for crud Operation 
        public DbSet<Projects> projects { get; set; }

        public DbSet<Employee> employee { get; set; }
        //commands
        //dotnet ef migrations add InitialCreate
        //add migration
        //Enable-Migrations -StartUpProjectName NGCore_Blog -ContextTypeName NGCore_Blog.Data.ApplicationDbContext -Verbose
        public DbSet<EmployeeProject> employeeProject { get; set; }
    }
}
