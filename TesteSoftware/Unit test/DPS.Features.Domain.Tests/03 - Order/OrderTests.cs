﻿namespace DPS.Features.Domain.Tests
{
    [TestCaseOrderer("DPS.Features.Domain.Tests.PriorityOrderer", "DPS.Features.Domain.Tests")]
    public class OrderTests
    {
        public static bool Test1Called;
        public static bool Test2Called;
        public static bool Test3Called;
        public static bool Test4Called;

        [Fact(DisplayName = "Test 04"), TestPriority(3)]
        [Trait("Category", "Order Tests")]
        public void Test04()
        {
            Test4Called = true;

            Assert.True(Test3Called);
            Assert.True(Test1Called);
            Assert.False(Test2Called);
        }

        [Fact(DisplayName = "Test 01"), TestPriority(2)]
        [Trait("Category", "Order Tests")]
        public void Test01()
        {
            Test1Called = true;

            Assert.True(Test3Called);
            Assert.False(Test4Called);
            Assert.False(Test2Called);
        }

        [Fact(DisplayName = "Test 03"), TestPriority(1)]
        [Trait("Category", "Order Tests")]
        public void Test03()
        {
            Test3Called = true;

            Assert.False(Test1Called);
            Assert.False(Test2Called);
            Assert.False(Test4Called);
        }

        [Fact(DisplayName = "Test 02"), TestPriority(4)]
        [Trait("Category", "Order Tests")]
        public void Test02()
        {
            Test2Called = true;

            Assert.True(Test3Called);
            Assert.True(Test4Called);
            Assert.True(Test1Called);
        }
    }
}