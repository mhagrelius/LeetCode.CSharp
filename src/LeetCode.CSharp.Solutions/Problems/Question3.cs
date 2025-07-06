namespace LeetCode.CSharp.Solutions.Problems;
/*
 * Given a string s, find the length of the longest substring without duplicate characters.
   
   Example 1:
   
   Input: s = "abcabcbb"
   Output: 3
   Explanation: The answer is "abc", with the length of 3.
   Example 2:
   
   Input: s = "bbbbb"
   Output: 1
   Explanation: The answer is "b", with the length of 1.
   Example 3:
   
   Input: s = "pwwkew"
   Output: 3
   Explanation: The answer is "wke", with the length of 3.
   Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
    
   
   Constraints:
   
   0 <= s.length <= 5 * 104
   s consists of English letters, digits, symbols and spaces.
 * 
 */
public class Question3
{
  public int LengthOfLongestSubstring(string s)
  {
    var longest = 0;
    var hashSet = new HashSet<char>();
    var start = 0;
    var end = 0;

    for (var i = 0; i < s.Length; i++)
    {
      if (hashSet.Add(s[i]))
      {
        end = i;
      }
      else
      {
        var newStart = s.IndexOf(s[i], start) + 1;
        end = i;
        hashSet = new HashSet<char>(end - newStart + 1);
        for (var j = newStart; j <= end; j++)
        {
          hashSet.Add(s[j]);
        }
        start = newStart;
      }

      if (end - start + 1 > longest)
      {
        longest = end - start + 1;
      }
    }

    return longest;
  }
  
  public int LengthOfLongestSubstringFaster(string s)
  {
    var longest = 0;
    var left = 0;
    var set = new HashSet<char>();
    for (var right = 0; right < s.Length; right++)
    {
      while (set.Contains(s[right]))
      {
        set.Remove(s[left]);
        left++;
      }
      
      set.Add(s[right]);
      var currentLength = right - left + 1; // off by one due to 0 index
      if (currentLength > longest)
      {
        longest = currentLength;
      }
    }
    return longest;
  }
}