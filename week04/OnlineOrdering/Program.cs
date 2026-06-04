using System;

class Program
{
    static void Main(string[] args)
    {

        Address address1 = new Address(
            "115 Merritt St",
            "Chapel Hill",
            "North Carolina",
            "USA");

        Customer customer1 = new Customer("Jackson Lee", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Men's Suit", "CLT101", 347.25m, 1));
        order1.AddProduct(new Product("Dress Shoes", "SHS102", 118.50m, 1));
        order1.AddProduct(new Product("Leather Briefcase", "BAG103", 176.75m, 1));


        Address address2 = new Address(
            "15 Liberation Road",
            "Airport Residential Area",
            "Accra",
            "Ghana");

        Customer customer2 = new Customer("Joel Dadzie", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Men's Kaftan", "CLT201", 82.40m, 2));
        order2.AddProduct(new Product("Leather Sandals", "SHS202", 43.15m, 1));
        order2.AddProduct(new Product("Study Bible", "BIB203", 27.80m, 1));


        Address address3 = new Address(
            "22 Admiralty Way",
            "Lekki Phase 1",
            "Lagos",
            "Nigeria");

        Customer customer3 = new Customer("Chinedu Mikel", address3);

        Order order3 = new Order(customer3);
        order3.AddProduct(new Product("Travel Backpack", "BAG301", 94.60m, 1));
        order3.AddProduct(new Product("Running Shoes", "SHS302", 131.25m, 1));
        order3.AddProduct(new Product("Holy Bible", "BIB303", 31.45m, 2));

        DisplayOrder(order1, 1);
        DisplayOrder(order2, 2);
        DisplayOrder(order3, 3);
    }

    static void DisplayOrder(Order order, int orderNumber)
    {
        Console.WriteLine($"Order {orderNumber}");

        Console.WriteLine("\nPACKING LABEL:");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("\nSHIPPING LABEL:");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine($"\nTOTAL PRICE: ${order.GetTotalCost():0.00}");

    }
}