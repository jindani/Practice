using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Arrays
{
    class RotateMatrix
    {
        public static void Rotate(int[][] a)
        {

        }

        public static void Test()
        {
            int[][] a = new int[][] { new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 } };
            Rotate(a);
            //a.ForEach(x => { Console.WriteLine(String.Concat(x, ",")); });
            Console.WriteLine();
        }
    }
}
