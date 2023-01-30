using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    internal class EmployeeDb : DbContext
    {
        public EmployeeDb() : base("EmployeeConnection") { }
        public DbSet<Employee> Employees { get; set; }
    }
}
