namespace Xunit.Repeat.net
{
    public sealed class RepeatDataAttributeAttribute : Xunit.Sdk.DataAttribute
    {
        private readonly int count;

        public RepeatDataAttributeAttribute(int count)
        {
            const int minimumCount = 1;
            if (count < minimumCount)
            {
                throw new System.ArgumentOutOfRangeException(
                    paramName: nameof(count),
                    message: "Repeat count must be greater than 0."
                    );
            }
            this.count = count;
        }

        public override System.Collections.Generic.IEnumerable<object[]> GetData(System.Reflection.MethodInfo testMethod)
        {
            foreach (var iterationNumber in System.Linq.Enumerable.Range(start: 1, count: this.count))
            {
                yield return new object[] { iterationNumber };
            }
        }
    }
}
