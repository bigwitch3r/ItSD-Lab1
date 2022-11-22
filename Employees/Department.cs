using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    internal class Department
    {
        public string Name { get; set; }

        Dictionary<Employee, Employeer> employees_list = new Dictionary<Employee, Employeer>();

        public void add_employee(Employee employee, Employeer employeer)
        {
            employees_list.Add(employee, employeer);
        }

        public Department(string name)
        {
            this.Name = name;
        }
    }
}
