using System;
using System.Collections.Generic;
using System.Linq;

namespace Solid1
{
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    class Order
    {
        private List<Item> itemList = new List<Item>();

        public IList<Item> GetItems()
        {
            return itemList.AsReadOnly();
        }

        public int GetItemCount()
        {
            return itemList.Count;
        }

        public void AddItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            itemList.Add(item);
        }

        public void DeleteItem(Item item)
        {
            itemList.Remove(item);
        }

        public decimal CalculateTotalSum()
        {
            return itemList.Sum(item => item.Price);
        }
    }

    class OrderPrinter
    {
        public void PrintOrder(Order order)
        {
            ShowOrder(order);
            Console.WriteLine("The order has been printed.");
        }

        public void ShowOrder(Order order)
        {
            Console.WriteLine("Order contents:");
            foreach (Item item in order.GetItems())
            {
                Console.WriteLine(item.Name + " - " + item.Price);
            }
            Console.WriteLine("Total amount: " + order.CalculateTotalSum());
        }
    }

    class OrderRepository
    {
        public Order Load()
        {
            Console.WriteLine("Loading the order...");
            return new Order();
        }

        public void Save(Order order)
        {
            Console.WriteLine("The order has been saved.");
        }

        public void Update(Order order)
        {
            Console.WriteLine("The order has been updated.");
        }

        public void Delete(Order order)
        {
            Console.WriteLine("The order has been deleted.");
        }
    }

    class Program
    {
        static void Main()
        {
            Order order = new Order();
            order.AddItem(new Item("Keyboard", 1200m));
            order.AddItem(new Item("Mouse", 650m));

            OrderPrinter printer = new OrderPrinter();
            printer.ShowOrder(order);

            OrderRepository repository = new OrderRepository();
            repository.Save(order);

        }
    }
}
