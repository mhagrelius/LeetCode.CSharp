namespace LeetCode.CSharp.Solutions.Problems;


/*
 * Given an array of integers nums and an integer target, return indices of the two numbers such that they add
 * up to target.
 *
 * You may assume that each input would have exactly one solution, and you may not use the same element twice.
 *
 * You can return the answer in any order.
 *
 * Constraints:
   
   2 <= nums.length <= 104
   -109 <= nums[i] <= 109
   -109 <= target <= 109
   Only one valid answer exists.
   
 */
public class Question1
{
    public int[] TwoSum(int[] nums, int target)
    {
        var multiplier = target > 0 ? 1 : -1;
        var values = new List<(int, int)>();
        for(var i = 0; i < nums.Length; i++)
        {
            if (nums[i] * multiplier > target * multiplier)
            {
                continue;
            }
            var match = values.Where(v => v.Item2 + nums[i] == target).ToList();
            if(match.Any())
            {
                return [match[0].Item1, i];
            }
            values.Add((i, nums[i]));
        }
        return [];
    }
    
    public int[] TwoSumFaster(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (map.TryGetValue(nums[i], out var value))
            {
                return [value, i];
            }
            map[target - nums[i]] = i;
        }

        return [];
    }
}