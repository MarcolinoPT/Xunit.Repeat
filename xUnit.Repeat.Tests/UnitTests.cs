namespace Xunit.Repeat.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class When_Using_Repeat_Attribute
    {
        public class With_Repeat_Count_Lower_Or_Equal_To_Zero
        {
            [Theory()]
            [InlineData(new object[] { 0 })]
            [InlineData(new object[] { -1 })]
            [InlineData(new object[] { -1000 })]
            [InlineData(new object[] { int.MinValue })]
            public void It_should_throw_ArgumentException(int count)
            {
                // Arrange/Act
                Action act = () => new RepeatAttribute(count: count);
                // Assert
                act.Should()
                    .Throw<ArgumentOutOfRangeException>(because: "count is equal or lower than zero");
            }
        }

        public class With_Repeat_Count_Bigger_Than_Zero
        {
            [Fact()]
            public void It_should_have_expected_count()
            {
                // Arrange
                const int count = 2;
                var sut = new RepeatAttribute(count: count);
                // Act
                var iterationNumbers = sut.GetData(testMethod: null);
                // Assert
                iterationNumbers.Should()
                    .HaveCount(expected: count);
            }

            [Fact()]
            public void It_should_have_all_iteration_numbers()
            {
                // Arrange
                const int count = 2;
                var sut = new RepeatAttribute(count: count);
                var iterations = new List<object[]>
                {
                    new object[]{ 1 },
                    new object[]{ 2 }
                };
                // Act
                var iterationNumbers = sut.GetData(testMethod: null);
                // Assert
                iterationNumbers.Should()
                    .BeEquivalentTo(iterations);
            }
        }
    }
}
