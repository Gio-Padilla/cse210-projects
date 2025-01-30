using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Address address1 = new Address("123 North Street", "Orem", "Utah", "United States");
        Address address2 = new Address("Calle Rivera Navarrete 737", "San Isidro", "Lima ", "Peru");

        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Maria Fernanda", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Egg", 1059, 0.99f, 12));
        order1.AddProduct(new Product("Bread", 2014, 3.59f, 2));
        order1.AddProduct(new Product("Apple", 3048, 1.29f, 10));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Tomato", 1542, 1.19f, 5));
        order2.AddProduct(new Product("Milk", 2001, 4.69f, 1));
        order2.AddProduct(new Product("Butter", 1006, 2.89f, 4));

        Console.WriteLine(order1.GetShippingString());
        Console.WriteLine("===============================");
        Console.WriteLine(order1.GetPackingString());
        Console.Write("Shipping Cost: $");
        Console.WriteLine($"{order1.GetShippingCost():f2}");
        Console.Write("Total Cost: $");
        Console.WriteLine($"{order1.GetTotalCost():f2}");

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine(order2.GetShippingString());
        Console.WriteLine("===============================");
        Console.WriteLine(order2.GetPackingString());
        Console.Write("Shipping Cost: $");
        Console.WriteLine($"{order2.GetShippingCost():f2}");
        Console.Write("Total Cost: $");
        Console.WriteLine($"{order2.GetTotalCost():f2}");


    }
}