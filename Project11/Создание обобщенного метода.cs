using System;

class ArrayUtils
{
    /*
      В методах, объявляемых в обобщенных классах, может использоваться параметр типа из данного класса, 
      а следовательно, такие методы автоматически становятся обобщенными по отношению к параметру типа. 
      Но помимо этого имеется возможность объявить обобщенный метод со своими собственными параметрами 
      типа и даже создать обобщенный метод, заключенный в необобщенном классе.
    */
    public static bool CopyInsert<T>(T e, uint idx,
                                     T[] src, T[] target)
    {

        if (target.Length < src.Length + 1)
            return false;

        for (int i = 0, j = 0; i < src.Length; i++, j++)
        {
            if (i == idx)
            {
                target[j] = e;
                j++;
            }
            target[j] = src[i];
        }

        return true;
    }

    public static void Test<V>(V a, V b)
    {
        Console.WriteLine("{0} {1}", a.GetType(), b.GetType());
    }

}

class GenMethDemo
{
    static void Main()
    {
        char c = 'A';
        int b = 10; 
        double d = 7.5;
        ArrayUtils.Test(c, b);    
        ArrayUtils.Test(d, b);

        // ArrayUtils.Test(true, 10); // Ошибка компиляции: невозможно специфицировать параметр V

        int[] nums = { 1, 2, 3, 4, 5 };
        int[] nums2 = new int[6];

        Console.Write("Contents of nums: ");
        foreach (int x in nums)
            Console.Write(x + " ");

        Console.WriteLine();

        ArrayUtils.CopyInsert(99, 2, nums, nums2);

        Console.Write("Contents of nums2: ");
        foreach (int x in nums2)
            Console.Write(x + " ");

        Console.WriteLine();


        string[] strs = { "Generics", "are", "powerful." };
        string[] strs2 = new string[4];

        Console.Write("Contents of strs: ");
        foreach (string s in strs)
            Console.Write(s + " ");

        Console.WriteLine();

        ArrayUtils.CopyInsert("in C#", 1, strs, strs2);

        Console.Write("Contents of strs2: ");
        foreach (string s in strs2)
            Console.Write(s + " ");

        Console.WriteLine();

    }
}
