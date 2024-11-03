using System;

namespace Generic_delegates
{
    delegate T MyDelegate<T>(T a, T b);

    class MySum
    {
        public static int SumInt(int a, int b)
        {
            return a + b;
        }

        public static string SumStr(string s1, string s2)
        {
            return s1 + " " + s2;
        }

        public static char SumCh(char a, char b)
        {
            return (char)(a + b);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate<int> del1 = MySum.SumInt;
            Console.WriteLine("10 + 7 = " + del1(10, 7));

            MyDelegate<string> del2 = MySum.SumStr;
            Console.WriteLine("\"Generic\" + \"delegates\" = " + del2("Generic", "delegates"));

            MyDelegate<char> del3 = MySum.SumCh;
            Console.WriteLine("'1' + '2' = " + del3('1', '2'));
        }
    }
}
