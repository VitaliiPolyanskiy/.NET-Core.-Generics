using System;
using System.Collections.Generic;

class Club: IComparable<Club>
{
    string name;
    string city;
    int year;
    public Club(string name, string city, int year)
    {
        this.name = name;
        this.city = city;
        this.year = year;
    }
    public void Show()
    {
        Console.WriteLine("\n{0}   {1}   {2}", name, city, year);
    }
    public int CompareTo(Club obj)
    {
        return name.CompareTo(obj.name);
    }

    public class SortByName : IComparer<Club>
    {
        int IComparer<Club>.Compare(Club obj1, Club obj2)
        {
            return obj1.name.CompareTo(obj2.name);
        }
    }

    public class SortByCity : IComparer<Club>
    {
        int IComparer<Club>.Compare(Club obj1, Club obj2)
        {
            return obj1.city.CompareTo(obj2.city);
        }
    }

    public class SortByYear : IComparer<Club>
    {
        int IComparer<Club>.Compare(Club obj1, Club obj2)
        {
            return obj1.year.CompareTo(obj2.year);
        }
    }
}

class MainClass
{
    public static void Main()
    {
        Club[] c = new Club[6];
        Console.WriteLine("Неупорядоченный массив:");
        c[0] = new Club("Динамо", "Киев", 1927);
        c[1] = new Club("Арсенал", "Лондон", 1886);
        c[2] = new Club("Интер", "Милан", 1908);
        c[3] = new Club("Бавария", "Мюнхен", 1900);
        c[4] = new Club("Челси", "Лондон", 1905);
        c[5] = new Club("Реал", "Мадрид", 1902);
        foreach (Club temp in c)
            temp.Show();

        Array.Sort(c);
        Console.WriteLine("\nУпорядоченный массив:");
        foreach (Club temp in c)
            temp.Show();

        Array.Sort(c, new Club.SortByYear());
        Console.WriteLine("\nМассив, упорядоченный по году основания:");
        foreach (Club temp in c)
            temp.Show();

        Array.Sort(c, new Club.SortByCity());
        Console.WriteLine("\nМассив, упорядоченный по названию города:");
        foreach (Club temp in c)
            temp.Show();

        Array.Sort(c, new Club.SortByName());
        Console.WriteLine("\nМассив, упорядоченный по названию клуба:");
        foreach (Club temp in c)
            temp.Show();
    }
}



