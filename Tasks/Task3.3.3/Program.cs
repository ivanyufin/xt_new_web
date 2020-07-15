using System;
using System.Threading;

namespace Task3._3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("Ivan");
            Client client1 = new Client("Vova");
            client1.MakeAnOrder(new Carbonara(25));
            client.MakeAnOrder(new Pepperoni(25));
            Console.ReadKey();
        }
    }

    public static class Pizzeria
    {
        public delegate void MakePizzaDelegate(string name);
        public static event MakePizzaDelegate MakePizzaHandler;

        public static void StatusOrder(string name, Pizza pizza)
        {
            Console.WriteLine("Make a pizza " + pizza.Name);
            Thread.Sleep(1000);
            MakePizza(name, pizza);
        }

        private static void MakePizza(string name, Pizza pizza)
        {
            Console.WriteLine(name + ", your pizza " + pizza.Name + " ready");
            MakePizzaHandler?.Invoke(name);
        }
    }

    public class Client
    {
        public Client(string name)
        {
            this.name = name;
            Pizzeria.MakePizzaHandler += PickUpPizza;
        }

        private string name = "";
        public string Name
        {
            get
            {
                return name;
            }
        }

        public void MakeAnOrder(Pizza pizza)
        {
            Console.WriteLine("Making an order");
            Pizzeria.StatusOrder(this.name, pizza);
        }

        public void PickUpPizza(string name)
        {
            if(name == this.name)
                Console.WriteLine("Took, thanks");
        }
    }

    public abstract class Pizza
    {
        private int size;
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                if(size > 0)
                    size = value;
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }

    public class Pepperoni : Pizza
    {
        public Pepperoni(int size)
        {
            this.Size = size;
            this.Name = "Pepperoni";
        }
    }

    public class Carbonara : Pizza
    {
        public Carbonara(int size)
        {
            this.Size = size;
            this.Name = "Carbonara";
        }
    }

    public class CheesePizza : Pizza
    {
        public CheesePizza(int size)
        {
            this.Size = size;
            this.Name = "CheesePizza";
        }
    }
}
