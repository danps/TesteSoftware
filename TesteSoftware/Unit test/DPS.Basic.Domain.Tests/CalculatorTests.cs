﻿using  DPS.Basic.Domain.Models;

namespace DPS.Basic.Domain.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_Add_ReturnSumValue()
        {
            // Arrange
            var Calculator = new Calculator();

            // Act
            var result = Calculator.Add(2, 2);

            // Assert
            Assert.Equal(4, result);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(4, 2, 6)]
        [InlineData(7, 3, 10)]
        [InlineData(6, 6, 12)]
        [InlineData(9, 9, 18)]
        public void Calculator_Add_ReturnCorrectSumValues(double v1, double v2, double total)
        {
            // Arrange
            var Calculator = new Calculator();

            // Act
            var result = Calculator.Add(v1, v2);

            // Assert
            Assert.Equal(total, result);
        }
    }
}