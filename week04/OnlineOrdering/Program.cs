using System;

class Program
{
    static void Main(string[] args)
    {
        // Order #1 - USA customer
        Address address1 = new Address("123 Main St", "Salt Lake City", "UT", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Notebook", "N123", 2.50m, 4));
        order1.AddProduct(new Product("Pen", "P456", 1.25m, 10));

        // Order #2 - International customer
        Address address2 = new Address("12 Oxford Road", "London", "Greater London", "UK");
        Customer customer2 = new Customer("James Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("USB Drive", "U789", 12.00m, 2));
        order2.AddProduct(new Product("Wireless Mouse", "M101", 20.00m, 1));
        order2.AddProduct(new Product("Keyboard", "K112", 30.00m, 1));

        // Display orders
        DisplayOrder(order1);
        Console.WriteLine("----------------------------");
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalCost()}\n");
    }
}
