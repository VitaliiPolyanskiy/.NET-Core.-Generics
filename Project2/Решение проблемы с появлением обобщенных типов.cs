using System;

// Параметр T в угловых скобках называется универсальным параметром, 
// так как вместо него можно подставить любой тип
class Gen<T> 
{
    readonly T ob; 

    public Gen(T o)
    {
        ob = o;
    }

    public T GetOb()
    {
        return ob;
    }

    public void ShowType()
    {
        Console.WriteLine("Type of T is " + typeof(T));
    }
}

/*
 Одним из основных преимуществ обобщений является производительность. 
 Использование типов значений с необобщенными классами коллекций 
 вызывает упаковку (boxing) и распаковку (unboxing) при преобразовании в ссылочный тип и обратно.
 
 Другим свойством обобщений является безопасность типов. 
 Обобщения автоматически обеспечивают типовую безопасность всех операций. 
 В ходе выполнения этих операций обобщения исключают необходимость обращаться 
 к приведению типов и проверять соответствие типов в коде вручную.
 */
class GenericsDemo
{
    static void Main()
    {
        Gen<int> iOb = new Gen<int>(7);

        iOb.ShowType();

        int v = iOb.GetOb();
        Console.WriteLine("value: " + v);

        Console.WriteLine();

        Gen<double> iOb2 = new Gen<double>(7);

        iOb2.ShowType();

        double d = iOb2.GetOb();
        Console.WriteLine("value: " + d);

        Console.WriteLine();

        Gen<string> strOb = new Gen<string>("Generics");

        strOb.ShowType();

        string str = strOb.GetOb();
        Console.WriteLine("value: " + str);

        // Ошибка компиляции
        // iOb = strOb;
    }
}
