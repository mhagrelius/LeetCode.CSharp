namespace LeetCode.CSharp.Solutions.Problems;

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