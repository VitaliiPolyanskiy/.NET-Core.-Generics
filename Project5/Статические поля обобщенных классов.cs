using System;

namespace Static_fields 
{
    class MyGeneric<T>
    {
        static public T var;
        public T PropVal { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyGeneric<int> obj1 = new MyGeneric<int>
            {
                PropVal = 10
            };
            MyGeneric<int>.var = 7;
            Console.WriteLine(obj1.PropVal);
            Console.WriteLine(MyGeneric<int>.var);


            MyGeneric<string> obj2 = new MyGeneric<string>
            {
                PropVal = "Generic"
            };
            MyGeneric<string>.var = "Static";
            Console.WriteLine(obj2.PropVal);
            Console.WriteLine(MyGeneric<string>.var);
        }
    }
}
