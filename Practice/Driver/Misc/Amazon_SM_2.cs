using System;
using System.Collections.Generic;
using System.Text;

namespace Misc
{
    public class Amazon_SM_2
    {
        public String solution(int AX,int AY, int BX, int BY)
        {
            // Line formula Y=MX + C ==> Ax + By = C
            if(AY == BY)
            {
                if (AX < BX)
                    return BX + "," + (BY-1);
                return AX + "," + (BY + 1);
            }
            else if(AX == BX)
            {
                if (AY < BY)
                    return (AX+1)+"," + BY;
                return (AX - 1) + "," + BY;
            }
            int b = BY - AY;
            int a = AX - BX;
            int c = b * BY - a * BX;
            int add = 0;
            if (AX < BX && AY > BY)
                add = -1;
            else if (AX < BX && AY > BY)
                add = 1;
            else if (AX > BX && AY > BY)
                add = -1;
            else
                add = 1;
            for (int x = BX+add; ; x += add)
            {
                if ((a * x + c) % b == 0)
                    return x + "," + (a * x + c) / b;
            }

        }
        public static void Test()
        {
            Console.WriteLine(new Amazon_SM_2().solution(2,2,2,-3));
        }
    }
}
