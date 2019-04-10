using System;
using System.IO;

namespace InheritenceDemo
{
    interface IComparable
    {
        int Compare(int a);
    }
    class C:B, IComparable
    {
        new int a;

        public C()
        {
        }

        public int Compare(int a)
        {
            return -1;
        }

        public override void Get()
        {
            throw new NotImplementedException();
        }
    }
    class A
    {
        public int a;
        public A(int x) : this()
        {
            a = x;
        }
        public A()
        {

        }
        public int PropertyDemo
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
            }
        }
        public virtual int virtualDemo(int x)
        {
            return x;
        }
        public int HideDemo()
        {
            return -1;
        }
        public int this[int x]
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
            }
        }
    }

    abstract class B : A
    {

        new int a;

        public B():base(1)
        {

        }
        public new int HideDemo()
        {
            return -1;
        }
        public override int virtualDemo(int x)
        {
            return x & base.a & base.HideDemo() | HideDemo() ;
        }
        public abstract void Get();
    }
    class Program
    {

        public static void IODemo()
        {
            FileStream f = new FileStream("D:\\test.txt", FileMode.Open,FileAccess.Read);
            byte[] buff = new byte[10];
            for (int i = 0; i < 10; i++)
                buff[i]= (byte)i;
            f.Write(buff, 0, 10);
            f.Flush();
            f.Seek(-5, SeekOrigin.Current);
            byte[] read = new byte[5];
            f.Read(read, 0, 5);
            for (int i = 0; i < 5; i++)
                Console.WriteLine(read[i]);
           

            using (BinaryWriter str = new BinaryWriter(new FileStream("D:\\test.txt", FileMode.Create)))
            {
                str.Write(true);
                str.Write("Abc");
                str.Write("Xyz");
            }
            using (BinaryReader str = new BinaryReader(new FileStream("D:\\test.txt", FileMode.Open)))
            {
                Console.WriteLine(str.ReadBoolean());
                
                if (str.BaseStream.Position == str.BaseStream.Length)
                {
                    Console.WriteLine("Endding file");
                }
                //Span<char> span = new Span<char>();

            }
        }
        static void Main(string[] args)
        {
            //IODemo();
            ItteratorDemo.Test();

            Console.ReadLine();

        }
    }
}
