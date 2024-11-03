using System;

class ArrayUtils
{
    public static bool CopyInsert<T>(T e, uint idx,
                                     T[] src, T[] target) where T: class
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
}

class GenMethDemo
{
    static void Main()
    {
        int[] nums = { 1, 2, 3 };
        int[] nums2 = new int[4];

        Console.Write("Contents of nums: ");
        foreach (int x in nums)
            Console.Write(x + " ");

        Console.WriteLine();

       // ArrayUtils.CopyInsert(99, 2, nums, nums2);
        // Ошибка компиляции: параметризированный тип T должен специфицироваться ссылочным типом

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
