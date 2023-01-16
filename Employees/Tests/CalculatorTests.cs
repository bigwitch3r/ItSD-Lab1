using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Employees.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void SalaryCalculationTest()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.SalaryCalculation(40, 200);

            // Assert
            Assert.Equal(8000, result);
        }

        [Fact]
        public void NdflCalculationTest()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.NdflCalculation(10000);

            // Assert
            Assert.Equal(1300, result);
        }
    }
}
