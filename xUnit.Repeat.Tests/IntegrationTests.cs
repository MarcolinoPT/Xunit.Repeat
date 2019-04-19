namespace Xunit.Repeat.Tests
{
    using FluentAssertions;
    using Xunit;
    using Xunit.Priority;

    [TestCaseOrderer(ordererTypeName: PriorityOrderer.Name, ordererAssemblyName: PriorityOrderer.Assembly)]
    public class IntegrationTests
    {
        private const int RepeatCount = 10;
        private static int Counter;

        [Theory(DisplayName = "It should repeat the test"), Priority(1)]
        [Repeat(RepeatCount)]
        public void It_should_repeat_the_test(int interationNumber)
        {
            ++Counter;
        }

        [Fact(DisplayName = "It should have repeated the test"), Priority(2)]
        public void It_should_have_repeated_the_test()
        {
            Counter
                .Should()
                .Be(RepeatCount);
        }
    }
}
