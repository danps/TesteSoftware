namespace DPS.Basic.Domain.Tests
{
    public class AssertStringsTests
    {
        [Fact]
        public void StringsTools_MergeNames_ReturnFullName()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullname = sut.FullName("Foo", "Bar");

            // Assert
            Assert.Equal("Foo Bar", fullname);
        }

        [Fact]
        public void StringsTools_MergeNames_ShouldIgnoreCase()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.FullName("Foo", "Bar");

            // Assert
            Assert.Equal("FOO BAR", fullName, true);
        }

        [Fact]
        public void StringsTools_MergeNames_MustContainExcerpt()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.FullName("Foo", "Bar");

            // Assert
            Assert.Contains("oo", fullName);
        }

        [Fact]
        public void StringsTools_MergeNames_MustStartWith()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.FullName("Foo", "Bar");

            // Assert
            Assert.StartsWith("Fo", fullName);
        }

        [Fact]
        public void StringsTools_MergeNames_MustEndWith()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.FullName("Foo", "Bar");

            // Assert
            Assert.EndsWith("ar", fullName);
        }

        [Fact]
        public void StringsTools_MergeNames_ValidateRegularExpression()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.FullName("Foo", "Bar");

            // Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", fullName);
        }
    }
}