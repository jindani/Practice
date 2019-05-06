using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class PalindromSplit
    {
        public bool IsPalindrom(string str)
        {
            int n = str.Length;
            if (n <= 1) return true;
            for (int i = 0; i < n / 2; i++)
            {
                if (str[i] != str[n - i-1])
                {

                    return false;
                }
            }
            return true;
        }
        public IList<IList<int>> PalindromePairs(string[] w)
        {
            Dictionary<String, int> map = new Dictionary<String, int>();
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < w.Length; i++)
            {
                if (w[i] == "")
                    continue;
                map[new String(w[i].Reverse().ToArray())] = i;
            }

            for (int i = 0; i < w.Length; i++)
            {
                if (w[i] == "")
                {
                    for (int j = 0; j < w.Length; j++)
                    {
                        if (i == j)
                            continue;
                        if (IsPalindrom(w[j]))
                        {
                            res.Add(new List<int>(new int[] { i, j }));
                            res.Add(new List<int>(new int[] { j, i }));
                        }
                    }
                    continue;
                }
                for (int j = 1; j <= w[i].Length; j++)
                {
                    String toCheck = w[i].Substring(0, j);
                    //Console.WriteLine(toCheck);
                    int found = -1;
                    if (map.TryGetValue(toCheck, out found))
                    {
                        if (i != found && IsPalindrom(w[i].Substring(j)))
                        {
                            Console.WriteLine("{0} {1}", toCheck, w[i].Substring(0, w[i].Length - j));
                            res.Add(new List<int>(new int[] { i, found }));
                        }
                    }
                    if (toCheck == w[i].Substring(w[i].Length - j))
                        continue;
                    toCheck = w[i].Substring(w[i].Length - j);
                    if (map.TryGetValue(toCheck, out found))
                    {
                        if (i != found && IsPalindrom(w[i].Substring(0, w[i].Length-toCheck.Length)))
                        {
                            Console.WriteLine("{0} {1}", toCheck, w[i].Substring(0, j));
                            res.Add(new List<int>(new int[] { found, i }));
                        }
                    }
                }

            }

            return res;
        }

        public static void Test()
        {
            String[] w = new string[] { "abcd", "dcba" };
            new PalindromSplit().PalindromePairs(w);
        }
    }
}
