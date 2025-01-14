using  DPS.Basic.Domain.Models;

namespace DPS.Basic.Domain.Tests
{
    public class AssertingRangesTests
    {
        [Theory]
        [InlineData(700)]
        [InlineData(1500)]
        [InlineData(2000)]
        [InlineData(7500)]
        [InlineData(8000)]
        [InlineData(15000)]
        public void Employee_Salary_SalaryRangesMustRespectProfessionalLevel(double salario)
        {
            // Arrange & Act
            var employee = new Employee("Foo", salario);

            // Assert
            if (employee.ProfessionalLevel == ProfessionalLevel.Junior)
                Assert.InRange(employee.Salary, 500, 1999);

            if (employee.ProfessionalLevel == ProfessionalLevel.Full)
                Assert.InRange(employee.Salary, 2000, 7999);

            if (employee.ProfessionalLevel == ProfessionalLevel.Senior)
                Assert.InRange(employee.Salary, 8000, double.MaxValue);

            Assert.NotInRange(employee.Salary, 0, 499);
        }
    }
}