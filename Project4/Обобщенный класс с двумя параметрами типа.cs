using System;

class TwoGen<T, V>
{
    public TwoGen(T o1, V o2)
    {
        GetObj1 = o1;
        GetObj2 = o2;
    }

    public void ShowTypes()
    {
        Console.WriteLine("Type of T is " + typeof(T));
        Console.WriteLine("Type of V is " + typeof(V));
    }

    public T GetObj1 { get; }

    public V GetObj2 { get; }
}

class SimpGen
{
    static void Main()
    {

        TwoGen<int, string> tgObj =
          new TwoGen<int, string>(7, "generics");

        tgObj.ShowTypes();

        int v = tgObj.GetObj1;
        Console.WriteLine("value: " + v);

        string str = tgObj.GetObj2;
        Console.WriteLine("value: " + str);
    }
}
