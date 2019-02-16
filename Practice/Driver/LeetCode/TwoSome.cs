using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class TwoSome
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(target - nums[i]))
                {
                    return new int[] {map[target-nums[i]], i };
                }
                else
                {
                    if (map.ContainsKey(nums[i]))
                    {
                        continue;
                    }
                    map.Add(nums[i], i);
                }
            }
            return new int[] { };
        }
    }
}
