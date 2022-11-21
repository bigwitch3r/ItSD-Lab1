using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    internal class Employee
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Patronymic { get; set; }

        public string Gender { get; set; }
        public string Birthdate { get; set; }
        public string Work_Since { get; set; }

        public Employee(string fname, string lname, string patronymic,
            string gender, string bdate, string wsince) {
            First_Name = fname;
            Last_Name = lname;
            Patronymic = patronymic;
            Gender = gender;
            Birthdate = bdate;
            Work_Since = wsince;
        }

    }
}
