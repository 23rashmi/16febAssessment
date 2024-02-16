// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System;
using System.Collections.Generic;

class Program
{
    static SortedList<string, Product> productList = new SortedList<string, Product>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Product Management System");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Display Products");
            Console.WriteLine("4. Search Product");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    RemoveProduct();
                    break;
                case "3":
                    DisplayProducts();
                    break;
                case "4":
                    SearchProduct();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddProduct()
    {
        Console.WriteLine("Enter Product Details:");
        Console.Write("Product Name: ");
        string pname = Console.ReadLine();

        if (productList.ContainsKey(pname))
        {
            Console.WriteLine("Product with the same name already exists. Please choose a different name.");
            return;
        }

        Console.Write("Product Price: ");
        decimal pprice = decimal.Parse(Console.ReadLine());

        Console.Write("Product Brand: ");
        string pbrand = Console.ReadLine();

        Console.Write("Manufacturing Date: ");
        DateTime manufacturingDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Expiry Date: ");
        DateTime expiryDate = DateTime.Parse(Console.ReadLine());

        Product newProduct = new Product
        {
            Pname = pname,
            Pprice = pprice,
            Pbrand = pbrand,
            ManufacturingDate = manufacturingDate,
            ExpiryDate = expiryDate
        };

        productList.Add(pname, newProduct);

        Console.WriteLine("Product added successfully!");
    }

    static void RemoveProduct()
    {
        Console.Write("Enter the name of the product to remove: ");
        string pnameToRemove = Console.ReadLine();

        if (productList.ContainsKey(pnameToRemove))
        {
            productList.Remove(pnameToRemove);
            Console.WriteLine("Product removed successfully!");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    static void DisplayProducts()
    {
        Console.WriteLine("Product List:");
        foreach (var product in productList.Values)
        {
            Console.WriteLine($"Name: {product.Pname}, Price: {product.Pprice}, Brand: {product.Pbrand}, Manufacturing Date: {product.ManufacturingDate}, Expiry Date: {product.ExpiryDate}");
        }
    }

    static void SearchProduct()
    {
        Console.Write("Enter the name of the product to search: ");
        string pnameToSearch = Console.ReadLine();

        if (productList.ContainsKey(pnameToSearch))
        {
            Product foundProduct = productList[pnameToSearch];
            Console.WriteLine($"Product found - Name: {foundProduct.Pname}, Price: {foundProduct.Pprice}, Brand: {foundProduct.Pbrand}, Manufacturing Date: {foundProduct.ManufacturingDate}, Expiry Date: {foundProduct.ExpiryDate}");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
}

class Product
{
    public string? Pname { get; set; }
    public decimal Pprice { get; set; }
    public string? Pbrand { get; set; }
    public DateTime ManufacturingDate { get; set; }
    public DateTime ExpiryDate { get; set; }
}
