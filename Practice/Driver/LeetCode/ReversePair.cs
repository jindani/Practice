using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{

    public class ReversePair
    {
        public int MergeSort(int[] a, int start, int end)
         {
            if (start == end)
                return 0;
            int mid = start + (end - start) / 2;

            int res = MergeSort(a, start, mid);
            res += MergeSort(a, mid + 1, end);

            int[] temp = new int[end - start + 1];

            int k = 0;
            int i = start;
            int j = mid + 1;
            int sp = start;
            int spnag = mid + 1;
            int firstPosInSec = j;
            while (firstPosInSec <= end && a[firstPosInSec] <= 0)
                firstPosInSec++;
            firstPosInSec--;
            if (a[j] > 0)
                firstPosInSec = mid - 1;

            while (i <= mid && j <= end)
            {
                //Console.WriteLine(i+":"+j+":"+start+":"+end);
                if (a[i] <= a[j])
                {
                    //while(spnag<=firstPosInSec && a[spnag]<=a[i]*2 )
                    //spnag++;

                    //if(spnag<=firstPosInSec )
                    //{
                    //   res+=(firstPosInSec-spnag+1);
                    //}
                    temp[k++] = a[i++];
                }
                else
                {
                    sp = Math.Max(sp, i);
                    while (sp <= mid && (long)a[sp] <= (long)a[j] * 2)
                        sp++;

                    if (sp <= mid && a[sp] > (long)a[j] * 2)
                    {
                        res += (mid - sp + 1);
                    }
                    temp[k++] = a[j++];
                }
            }

            while (i <= mid)
                temp[k++] = a[i++];
            while (j <= end)
                temp[k++] = a[j++];

            for (i = start; i <= end; i++)
            {
                a[i] = temp[i - start];
            }
            return res;
        }
        public int ReversePairs(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            return MergeSort(nums, 0, nums.Length - 1);
        }

        public static void Test()
        {
            int[] a = new int[] { 2000000006, 235, 2000000003, 236 };
            Console.WriteLine(new ReversePair().ReversePairs(a));
        }
    }
}
