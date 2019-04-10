using System;
using System.Collections.Generic;

namespace Misc
{
    public class MyList
    {
        public List<MyList> listsOfMyLists = new List<MyList>();
        public List<Int32> listsOfIntegers = new List<int>();
    }
    public class LinkedInList
    {
        // return [maxDepth,sum]
        public static int[] GetSum(MyList myList)
        {
            int maxDepth = 0;
            int sum = 0;

            foreach (MyList list in myList.listsOfMyLists)
            {
                int[] res = GetSum(list);
                maxDepth = Math.Max(res[0], maxDepth);
                sum += res[1];
            }

            maxDepth = maxDepth + 1;// this node is at level maxDepth+1
            foreach (Int32 i in myList.listsOfIntegers)
            {
                sum += i * (maxDepth);
            }
            return new int[] { maxDepth, sum };
        }
        public static int Solve(MyList myList)
        {
            return GetSum(myList)[1];
        }

    }
}
