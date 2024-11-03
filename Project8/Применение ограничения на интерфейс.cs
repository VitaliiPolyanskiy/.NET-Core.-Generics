using System;
using System.Collections;

class MyIterator<T> where T : IEnumerable
{
    readonly T collection = default;

    public MyIterator(T collection)
    {
        this.collection = collection;
    }
    public void Print()
    {
        foreach(object obj in collection)
        {
            Console.Write(obj + " ");
        }
    }
}

class Test: IEnumerable
{
    string[] arr = null;
    public Test(params string[] arr)
    {
        this.arr = arr;
    }
    public IEnumerator GetEnumerator()
    {
        foreach (string i in arr)
        {
            yield return i;
        }
    }
}

class Demo
{
    static void Main()
    {
        try
        {
            ArrayList list =
            [
                "constraints",
                "on",
                "interface"
            ];
            MyIterator<ArrayList> obj = new(list);
            obj.Print();
            Console.WriteLine();

            string[] arr = ["constraints", "on", "interface"];
            MyIterator<string[]> obj2 = new(arr);
            obj2.Print();
            Console.WriteLine();

            Test test = new("constraints", "on", "interface");
            MyIterator<Test> obj3 = new MyIterator<Test>(test);
            obj3.Print();
            Console.WriteLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}