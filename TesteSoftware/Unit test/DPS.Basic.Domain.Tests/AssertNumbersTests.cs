using  DPS.Basic.Domain.Models;

namespace DPS.Basic.Domain.Tests
{
    public class AssertNumbersTests
    {
        [Fact]
        public void Calculator_Add_MustBeEqual()
        {
            // Arrange
            var Calculator = new Calculator();

            // Act
            var result = Calculator.Add(1, 2);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Calculator_Add_ShouldNotBeEqual()
        {
            // Arrange
            var Calculator = new Calculator();

            // Act
            var result = Calculator.Add(1.13123123123, 2.2312313123);

            // Assert
            Assert.NotEqual(3.3, result, 1);
        }
    }
}