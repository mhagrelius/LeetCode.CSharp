using System.Collections;
using FluentAssertions;
using LeetCode.CSharp.Solutions.Problems;

namespace LeetCode.CSharp.Tests.Problems;

public class Question1Tests
{
    [Theory]
    [ClassData(typeof(Question1TestData))]
    public void Test(int[] numbers, int target, int[] expectedResult)
    {
        var question = new Question1();
        var result = question.TwoSum(numbers, target);
        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [Theory]
    [ClassData(typeof(Question1TestData))]
    public void TestFaster(int[] numbers, int target, int[] expectedResult)
    {
        var question = new Question1();
        var result = question.TwoSumFaster(numbers, target);
        result.Should().BeEquivalentTo(expectedResult);
    }

    public class Question1TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return [new[] {0, 1, 2, 3, 4}, 7, new[] {3, 4}];
            yield return [new[] { 0, 1, 2 }, 5, Array.Empty<int>()];
            yield return [new[] { 0, -1, -2 }, -3, new[] { 1, 2 }];
            yield return [Array.Empty<int>(), 0, Array.Empty<int>()];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}