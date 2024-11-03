using System;

namespace Default_values
{
    class MyGeneric<T>
    {
        public T PropVal { get; set; }
        public void Reset()
        {
            // Оператор default присваивает ссылочным типам в качестве значения null, 
            // а типам значений - значение 0
            PropVal = default;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyGeneric<int> obj1 = new MyGeneric<int>
            {
                PropVal = 7
            };
            Console.WriteLine(obj1.PropVal);
            obj1.Reset();
            Console.WriteLine(obj1.PropVal);
            MyGeneric<string> obj2 = new MyGeneric<string>
            {
                PropVal = "Generic"
            };
            Console.WriteLine(obj2.PropVal);
            obj2.Reset();
            Console.WriteLine(obj2.PropVal);
        }
    }
}
