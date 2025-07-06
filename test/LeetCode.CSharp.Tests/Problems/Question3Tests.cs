using System.Collections;
using FluentAssertions;
using LeetCode.CSharp.Solutions.Problems;

namespace LeetCode.CSharp.Tests.Problems;

public class Question3Tests
{
    [Theory]
    [ClassData(typeof(Question3TestData))]
    public void Test(string input, int expectedResult)
    {
        var question = new Question3();
        var result = question.LengthOfLongestSubstring(input);
        result.Should().Be(expectedResult);
    }
    
    [Theory]
    [ClassData(typeof(Question3TestData))]
    public void TestFasterImplementation(string input, int expectedResult)
    {
        var question = new Question3();
        var result = question.LengthOfLongestSubstringFaster(input);
        result.Should().Be(expectedResult);
    }


    public class Question3TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return ["abcabcbb", 3];
            yield return ["bbbbb", 1];
            yield return ["pwwkew", 3];
            yield return ["", 0];
            yield return ["aab", 2];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}