using System;
using System.IO;

class MyStream<T> where T : Stream
{
    T stream = null;

    public void SetStream(T stream)
    {
        this.stream = stream;
    }
    public void Save()
    {
        BinaryWriter writer = new BinaryWriter(stream);
        writer.Write(".NET Framework");
        writer.Write("C#");
        writer.Write('A');
        writer.Write(65.78);
        writer.Write(true);
        writer.Close();
        stream.Close();
    }

    public void Load()
    {
        BinaryReader reader = new BinaryReader(stream);
        string s1 = reader.ReadString();
        string s2 = reader.ReadString();
        char c = reader.ReadChar();
        double d = reader.ReadDouble();
        bool b = reader.ReadBoolean();
        Console.WriteLine("string: {0}\nstring: {1}\nchar: {2}\ndouble: {3}\nbool: {4}",
            s1, s2, c, d, b);
        reader.Close();
        stream.Close();
    }
}

class Demo
{
    static void Main()
    {
        try
        {
            byte[] arr = new byte[255];
            MemoryStream stream = new MemoryStream(arr);
            MyStream<MemoryStream> obj = new MyStream<MemoryStream>();
            obj.SetStream(stream);
            obj.Save();
            stream = new MemoryStream(arr);
            obj.SetStream(stream);
            obj.Load();

            Console.WriteLine();

            FileStream file = new FileStream("1.dat", FileMode.Create, FileAccess.Write);
            MyStream<FileStream> obj2 = new MyStream<FileStream>();
            obj2.SetStream(file);
            obj2.Save();
            file = new FileStream("1.dat", FileMode.Open, FileAccess.Read);
            obj2.SetStream(file);
            obj2.Load();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}