namespace LeetCode.CSharp.Solutions.Problems;
#nullable disable

/*
 * You are given two non-empty linked lists representing two non-negative integers. The digits are stored in
 * reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as
 * a linked list.
 *
 * You may assume the two numbers do not contain any leading zero, except the number 0 itself.
 */
public class Question2
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        return AddTwoNumbersInternal(l1, l2);
    }

    private ListNode AddTwoNumbersInternal(ListNode l1, ListNode l2, int carry = 0)
    {
        var val = carry + (l1?.val ?? 0) + (l2?.val ?? 0);
        var newCarry = val / 10;
        var singleDigitVal = val % 10;


        if (l1?.next is null && l2?.next is null && newCarry == 0)
        {
            return new ListNode(singleDigitVal, null);
        }
        
        return new ListNode(singleDigitVal, AddTwoNumbersInternal(l1?.next, l2?.next, newCarry));
    }
}

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}