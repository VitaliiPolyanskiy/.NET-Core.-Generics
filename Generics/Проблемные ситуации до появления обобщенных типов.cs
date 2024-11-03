using System;

class NonGen
{
    readonly object ob; 

   public NonGen(object o)
    {
        ob = o;
    }

    public object GetOb()
    {
        return ob;
    }

    public void ShowType()
    {
        Console.WriteLine("Type of ob is " + ob.GetType());
        // Получает тип текущего экземпляра
    }
}

class NonGenDemo
{
    static void Main()
    {
        // Упаковка (boxing) предполагает преобразование объекта значимого типа (например, типа int) к типу object
        NonGen iOb = new NonGen(7); // Упаковка значения 7 в тип Object
        // При упаковке объеязыковая среда CLR обертывает значение в объект 
        // типа System.Object и сохраняет его в управляемой куче (heap)

        iOb.ShowType();

        // Распаковка (unboxing), наоборот, предполагает преобразование объекта типа object к значимому типу
        // Распаковка в значение типа int - приведение типов обязательно
        int v = (int)iOb.GetOb();
        Console.WriteLine("value: " + v);

        // Первая проблема: упаковка и распаковка ведут к снижению производительности, 
        // так как системе надо осуществить необходимые преобразования

        NonGen strOb = new NonGen("Non-Generics");

        strOb.ShowType();

        string str = (string)strOb.GetOb();
        Console.WriteLine("value: " + str);

        // Другая проблема - проблема безопасности типов
        iOb = strOb;

        // Получим ошибку во время выполнения программы
        //v = (int) iOb.GetOb(); 
    }
}