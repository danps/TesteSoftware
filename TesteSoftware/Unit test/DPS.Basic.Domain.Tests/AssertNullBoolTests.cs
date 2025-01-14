using  DPS.Basic.Domain.Models;

namespace DPS.Basic.Domain.Tests
{
    public class AssertNullBoolTests
    {
        [Fact]
        public void Employee_Name_MustNotBeNullOrEmpty()
        {
            // Arrange & Act
            var funcionario = new Employee("", 1000);

            // Assert
            Assert.False(string.IsNullOrEmpty(funcionario.Name));
        }

        [Fact]
        public void Employee_Apelido_MustNotHaveASurname()
        {
            // Arrange & Act
            var funcionario = new Employee("Foo", 1000);

            // Assert
            Assert.Null(funcionario.Surname);

            // Assert Bool
            Assert.True(string.IsNullOrEmpty(funcionario.Surname));
            Assert.False(funcionario.Surname?.Length > 0);
        }
    }
}