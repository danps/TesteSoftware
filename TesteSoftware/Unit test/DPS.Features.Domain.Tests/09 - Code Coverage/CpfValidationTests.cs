﻿
using DPS.Features.Domain.Core;
using FluentAssertions;

namespace DPS.Features.Domain.Tests
{
    public class CpfValidationTests
    {
        [Theory(DisplayName = "Valid CPFs")]
        [Trait("Category", "CPF Validation Tests")]
        [InlineData("15231766607")]
        [InlineData("78246847333")]
        [InlineData("64184957307")]
        [InlineData("21681764423")]
        [InlineData("13830803800")]
        public void Cpf_ValidateMultipleNumbers_AllShouldBeValid(string cpf)
        {
            // Assert
            var cpfValidation = new CpfValidation();

            // Act & Assert
            cpfValidation.IsValid(cpf).Should().BeTrue();
        }

        [Theory(DisplayName = "Invalid CPFs")]
        [Trait("Category", "CPF Validation Tests")]
        [InlineData("15231766607213")]
        [InlineData("528781682082")]
        [InlineData("35555868512")]
        [InlineData("36014132822")]
        [InlineData("72186126500")]
        [InlineData("23775274811")]
        public void Cpf_ValidateMultipleNumbers_AllShouldBeInvalid(string cpf)
        {
            // Assert
            var cpfValidation = new CpfValidation();

            // Act & Assert
            cpfValidation.IsValid(cpf).Should().BeFalse();
        }
    }
}