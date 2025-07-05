using System.Collections;
using FluentAssertions;
using LeetCode.CSharp.Solutions.Problems;
#nullable disable
namespace LeetCode.CSharp.Tests.Problems;

public class Question2Tests
{
    [Theory]
    [ClassData(typeof(Question2TestData))]
    public void Test(int[] firstNumber, int[] secondNumber, int[] resultNumber)
    {
        var l1 = GenerateListNodes(firstNumber);
        var l2 = GenerateListNodes(secondNumber);
        var expectedResult = GenerateListNodes(resultNumber);
        var question = new Question2();
        var result = question.AddTwoNumbers(l1, l2);
        result.Should().BeEquivalentTo(expectedResult);
    }
    
    private ListNode GenerateListNodes(params int[] values)
    {
        values = values.Reverse().ToArray();
        var firstNode = new ListNode(values[0]);
        var nodeList = firstNode;
        values = values[1..];
        foreach (var value in values)
        {
            nodeList.next = new ListNode(value);
            nodeList = nodeList.next;
        }

        return firstNode;
    }

    public class Question2TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new[] { new [] {3,4,2}, new []{4,6,5}, new[] {8,0,7} };
            yield return new[] { new [] {0}, new []{0}, new[] {0} };
            yield return new[] { new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new [] {1,0,0,0,9,9,9,8} };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }




    }
}