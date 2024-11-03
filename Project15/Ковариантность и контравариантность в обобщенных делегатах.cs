using System;

namespace Delegate
{
    class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public virtual void Display()
        {
            Console.WriteLine("Person: " + Name);
        }
    }
    class Client : Person
    {
        public Client(string name)
            : base(name)
        { }
        public override void Display()
        {
            Console.WriteLine("Client: " + Name);
        }
    }
    class Program
    {
        // Вариантность — перенос наследования исходных типов на производные от них типы.

        // Ковариантность — перенос наследования исходных типов на производные 
        // от них типы в прямом порядке.
        // Ковариантность позволяет присвоить делегату метод, 
        // возвращаемым типом которого служит класс, производный от класса, 
        // указываемого в возвращаемом типе делегата. 
        // Ковариантность позволяет использовать более конкретный тип, чем заданный изначально

        // ковариантный обобщенный делегат
        delegate T Builder<out T>(string name);

        private static Person GetPerson(string name)
        {
            return new Person(name);
        }
        private static Client GetClient(string name)
        {
            return new Client(name);
        }
        static Person Build(Builder<Person> personBuilder, string name)
        {
            return personBuilder(name);
        }

        // Контравариантность — перенос наследования исходных типов на производные 
        // от них типы в обратном порядке.
        // Контравариантность позволяет присвоить делегату метод, 
        // типом параметра которого служит класс, являющийся базовым для класса, 
        // указываемого в объявлении делегата.
        // Контравариантность позволяет использовать более универсальный тип, чем заданный изначально

        // контравариантный обобщенный делегат
        delegate void GetInfo<in T>(T item);

        private static void PersonInfo(Person p)
        {
            p.Display();
        }
        private static void ClientInfo(Client cl)
        {
            cl.Display();
        }
        static void Info(GetInfo<Client> clientInfo, Client p)
        {
            clientInfo(p);
        }

        static void Main(string[] args)
        {
            // Ковариантность
            Builder<Person> personBuilder = GetPerson;
            Builder<Client> clientBuilder = GetClient;

            Person p = Build(personBuilder, "Bill");
            p.Display();
            // Благодаря использованию out можно присвоить делегату типа Builder<Person> делегат типа Builder<Client>
            p = Build(clientBuilder, "John");
            p.Display();

            // Контравариантность
            GetInfo<Person> personInfo = PersonInfo;
            GetInfo<Client> clientInfo = ClientInfo;

            Client client = new Client("Bill");
            Info(clientInfo, client);
            // Использование ключевого слова in позволяет присвоить делегат с более универсальным типом (GetInfo<Person>) 
            // делегату с производным типом (GetInfo<Client>).
            client = new Client("John");
            Info(personInfo, client);
        }  
    }
}
