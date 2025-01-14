using  DPS.Basic.Domain.Models;

namespace DPS.Basic.Domain.Tests
{
    public class AssertingCollectionsTests
    {
        [Fact]
        public void Employee_Skills_MustNotHaveEmptySkills()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Foo", 10000);

            // Assert
            Assert.All(employee.Skills, skill => Assert.False(string.IsNullOrWhiteSpace(skill)));
        }

        [Fact]
        public void Employee_Skills_JuniorMustHaveBasicSkills()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Foo", 1000);

            // Assert
            Assert.Contains("OOP", employee.Skills);
        }

        [Fact]
        public void Employee_Skills_JuniorMustNotHaveAdvancedSkills()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Foo", 1000);

            // Assert
            Assert.DoesNotContain("Microservices", employee.Skills);
        }

        [Fact]
        public void Employee_Skills_SeniorMustHaveAllSkills()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Foo", 15000);

            var fullSkills = new[] { "Programming Logic", "OOP", "Tests", "Microservices" };

            // Assert
            Assert.Equal(fullSkills, employee.Skills);
        }
    }
}