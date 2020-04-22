namespace Xunit.Repeat.Tests
{
    using FluentAssertions;
    using Xunit;
    using Xunit.Priority;

    [TestCaseOrderer(ordererTypeName: PriorityOrderer.Name, ordererAssemblyName: PriorityOrderer.Assembly)]
    public class IntegrationTests
    {
        private const int _repeatCount = 10;
        private static int counter;

        [Theory(DisplayName = "It should repeat the test"), Priority(1)]
        [Repeat(_repeatCount)]
        public void It_should_repeat_the_test(int interationNumber)
        {
            ++counter;
        }

        [Fact(DisplayName = "It should have repeated the test"), Priority(2)]
        public void It_should_have_repeated_the_test()
        {
            counter.Should()
                .Be(_repeatCount);
        }
    }
}
