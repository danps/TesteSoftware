using  DPS.Basic.Domain.Models;

namespace DPS.Basic.Domain.Tests
{
    public class AssertingExceptionsTests
    {
        [Fact]
        public void Calculator_Div_ShouldReturnDivisionByZeroError()
        {
            // Arrange
            var Calculator = new Calculator();

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => Calculator.Div(10, 0));
        }


        [Fact]
        public void Employee_Salary_MustReturnErrorLowerSalaryAllowed()
        {
            // Arrange & Act & Assert
            var exception =
                Assert.Throws<Exception>(() => EmployeeFactory.Create("Foo", 250));

            Assert.Equal("Salary lower than allowed", exception.Message);
        }
    }
}