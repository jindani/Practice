using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class RotateArraySearch
    {
        
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            int start = 0, end = nums.Length - 1;
            do
            {
                int mid = start + (end - start) / 2;
                Console.WriteLine(start + ":" + end + ":" + mid);
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[start] <= nums[mid])
                {
                    if (nums[mid] > target && nums[start]<=target)
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
                else
                {
                    if (nums[mid] < target && target<=nums[end])
                        start = mid + 1;
                    else
                        end = mid - 1;

                }
                Console.WriteLine(start + ":" + end + ":" + mid);
            } while (start <= end);
            return -1;
        }

        public static void Test()
        {
            int[] a = new int[] {1, 3, 1, 1, 1};

            //Console.WriteLine(new RotateArraySearch().Search(a, 1));
            Console.WriteLine(new RotateArraySearch().Search(a, 3));
            //Console.WriteLine(new RotateArraySearch().Search(a, 13));

            for (int i = 0; i < -1; i++)
            {
                Console.WriteLine(new RotateArraySearch().Search(a, i));
            }
            //Console.WriteLine(new RotateArraySearch().Search(a, 2));
            
        }
    }
}
