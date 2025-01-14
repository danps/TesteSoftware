using  DPS.Basic.Domain.Models;

namespace DPS.Basic.Domain.Tests
{
    public class AssertingObjectTypesTests
    {
        [Fact]
        public void EmployeeFactory_Create_MustReturnEmployeeType()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Foo", 10000);

            // Assert
            Assert.IsType<Employee>(employee);
        }

        [Fact]
        public void EmployeeFactory_Create_MustReturnDerivedTypePerson()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Foo", 10000);

            // Assert
            Assert.IsAssignableFrom<Person>(employee);
        }
    }
}