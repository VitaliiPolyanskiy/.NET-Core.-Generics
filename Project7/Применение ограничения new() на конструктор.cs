using System;
using System.IO;

class MyStream<T> where T : Stream, new()
{
    readonly T stream = null;
    public MyStream()
    {
         stream = new T();
    }
    public void Save()
    {
        BinaryWriter writer = new BinaryWriter(stream);
        writer.Write(".NET Framework");
        writer.Write("C#");
        writer.Write('A');
        writer.Write(65.78);
        writer.Write(true);
        stream.Seek(0, SeekOrigin.Begin);
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
            MyStream<MemoryStream> obj = new MyStream<MemoryStream>();
            obj.Save();
            obj.Load();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}