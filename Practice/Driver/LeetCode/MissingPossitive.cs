using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class MissingPossitive
    {
        public int FirstMissingPositive(int[] nums)
        {
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] == i + 1)
                {
                    i++;
                    continue;
                }

                if (nums[i] > 0 && nums[i] <= nums.Length && nums[nums[i]-1] != nums[i])
                {
                    int temp = nums[nums[i] - 1];
                    nums[nums[i] - 1] = nums[i];
                    nums[i] = temp;
                }
                else
                {
                    i++;
                }

            }

            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != j + 1)
                {
                    return j + 1;
                }
            }
            return nums.Length + 1;
        }
        public static void Test()
        {
            Console.WriteLine(new MissingPossitive().FirstMissingPositive(new int[] { 1, 1 }));
        }
    }
    
}
