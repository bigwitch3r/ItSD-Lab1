using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    internal class Calculator
    {
        public int SalaryCalculate(int hours, int rate)
        {
            return hours * rate;
        }

        public double NdflCalculate(int salary)
        {
            return salary * 0.13;
        }
    }
}
