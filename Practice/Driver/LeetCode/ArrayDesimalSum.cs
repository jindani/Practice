using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class ArrayDesimalSum
    {
        public IList<int> AddToArrayForm(int[] A, int K)
        {
          
            int aptr = A.Length-1;
            List<int> result = new List<int>();
            int carry = 0;
            while (K > 0)
            {
                int t =K % 10 + carry;
                if (aptr >= 0)
                {
                    t += A[aptr]; 
                }
                
                result.Add(t % 10);
                carry = t / 10;
                K /= 10;
                aptr--;
            }
            while (aptr >= 0)
            {
                int t =carry + A[aptr];
                result.Add(t % 10);
                carry = t / 10;
                aptr--;
            }
            if (carry > 0)
            {
                result.Add(carry);
            }
            
            result.Reverse();
            return result;
        }
    }
}
