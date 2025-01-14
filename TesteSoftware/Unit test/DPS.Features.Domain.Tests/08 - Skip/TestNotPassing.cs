namespace DPS.Features.Domain.Tests
{
    public class TestNotPassing
    {
        [Fact(DisplayName = "New User 2.0", Skip = "New version 2.0 breaking")]
        [Trait("Category", "Skipping Tests")]
        public void Test_NotPassing_NewVersionNotCompatible()
        {
            Assert.True(false);
        }
    }
}