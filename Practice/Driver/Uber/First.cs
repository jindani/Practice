using System;

namespace Uber
{
    public class First
    {
        public static bool IsPossible(String[] words, int len)
        {
            int smsLen = 30;
            int suffixLen = 5; // (1/9)
            if (len > 10)
                suffixLen = 6;
            int parts = 0;
            int sum = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (parts < 9)
                {
                    if (smsLen - sum - words[i].Length - suffixLen - 1 >= 0) //30 - already fillded things - suffix length -1 space
                    {
                        sum += words[i].Length + 1;
                    }
                    else
                    {
                        parts++;
                        sum = words[i].Length + 1;
                    }
                }
                else
                {
                    if (smsLen - sum - words[i].Length - suffixLen - 2 >= 0) //30 - already fillded things - suffix length -1forpart no -1 space
                    {
                        sum += words[i].Length + 1;
                    }
                    else
                    {
                        parts++;
                        sum = words[i].Length + 1; ;
                    }
                }
            }
            if(sum!=0)
            {
                parts++;
            }
            if (parts <= len)
                return true;
            return false;
        }
        public static int Split(String s)
        {
            //Console.WriteLine(s.Length);
            if (s.Length <= 30)
                return 1;
            String[] words = s.Split(' ');
            int start = 1;
            int end = 100;
            while (start < end)
            {
                int mid = start + (end - start) / 2;
                if (IsPossible(words, mid))
                {
                    end = mid;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return start;
        }
        public static void Test()
        {
            //Console.WriteLine(Split("the best lies are always mixed with a little truth"));
            //Console.WriteLine(Split("there is no creature on earth half so terrifying as a truly just man!!!!!"));
            //Console.WriteLine(Split("1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890 1234567890"));
        }

        public int GetSubArray(int []a)
        {
            for(int i=0;i<a.Length;i++)
            {
                for(int j=i;j< a.Length; j++)
                {
                    
                }
            }
            return 0;
        }
    }
}
