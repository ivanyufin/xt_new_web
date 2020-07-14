using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3._3._3
{
    class Program
    {
        static void Main(string[] args)
        {

            Client client = new Client("Иван");

            client.MakeAnOrder();
            Console.ReadKey();
        }
    }

    public static class Pizzeria
    {
        public delegate void MakePizzaDelegate();
        public static event MakePizzaDelegate MakePizzaHandler;
        public static void StatusOrder(Client client)
        {
            Console.WriteLine("Готовим пиццу");
            Thread.Sleep(1000);
            MakePizza(client);
        }

        private static void MakePizza(Client client)
        {
            Console.WriteLine(client.Name + ", пицца готова");
            MakePizzaHandler?.Invoke();
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

        public delegate void MakeAnOrderDelegate(Client client);
        public event MakeAnOrderDelegate MakeAnOrderHandler;

        public void MakeAnOrder()
        {
            Console.WriteLine("Делаю заказ");
            MakeAnOrderHandler += Pizzeria.StatusOrder;
            MakeAnOrderHandler?.Invoke(this);
        }

        public void PickUpPizza()
        {
            Console.WriteLine("Забрал, спасибо");
        }
    }
}
