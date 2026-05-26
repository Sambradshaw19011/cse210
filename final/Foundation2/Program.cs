using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main Street", "Rexburg", "Idaho", "USA");
        Customer customer1 = new Customer("Sam Bradshaw", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "L1001", 899.99, 1));
        order1.AddProduct(new Product("Wireless Mouse", "M2002", 24.99, 2));
        order1.AddProduct(new Product("Keyboard", "K3003", 49.99, 1));

        Address address2 = new Address("45 Queen Street", "Toronto", "Ontario", "Canada");
        Customer customer2 = new Customer("Jordan Smith", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Backpack", "B4004", 39.99, 1));
        order2.AddProduct(new Product("Notebook", "N5005", 4.99, 5));
        order2.AddProduct(new Product("Water Bottle", "W6006", 14.99, 2));

        Console.WriteLine("Order 1");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():0.00}");

        Console.WriteLine("\n-----------------------------\n");

        Console.WriteLine("Order 2");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():0.00}");
    }
}