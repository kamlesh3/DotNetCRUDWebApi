using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCoreNew.Model;

namespace DemoProject.Model
{
    public class EmployeeContext: DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }
        public DbSet<TblEmployee> tblEmployee { get; set; } //Dataset property
        public DbSet<TblDesignation> tblDesignation { get; set; }
    }
}
