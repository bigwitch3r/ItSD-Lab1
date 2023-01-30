using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    internal class Calculator
    {
        private static Calculator instance;

        public Calculator() { }

        private static Calculator getInstance()
        {
            if (instance == null)
            {
                instance = new Calculator();
            }
            return instance;
        }

        public int SalaryCalculation(int hours, int rate)
        {
            return hours * rate;
        }

        public double NdflCalculation(int salary)
        {
            return salary * 0.13;
        }
    }
}
