using System;

class Program
{
    static void Main()
    {
        Product[] products = {
            new Product(1, "Laptop", "Electronics"),
            new Product(2, "Shoes", "Footwear"),
            new Product(3, "Keyboard", "Electronics"),
            new Product(4, "T-Shirt", "Apparel"),
            new Product(5, "Book", "Stationery")
        };

        // Sort for binary search by product name
        Array.Sort(products, (a, b) => a.ProductName.CompareTo(b.ProductName));

        string target = "Keyboard";

        Console.WriteLine("Linear Search:");
        var linearResult = LinearSearch(products, target);
        PrintResult(linearResult);

        Console.WriteLine("\nBinary Search:");
        var binaryResult = BinarySearch(products, target);
        PrintResult(binaryResult);
    }

    static Product? LinearSearch(Product[] products, string targetName)
    {
        foreach (var product in products)
        {
            if (product.ProductName.Equals(targetName, StringComparison.OrdinalIgnoreCase))
                return product;
        }
        return null;
    }

    static Product? BinarySearch(Product[] products, string targetName)
    {
        int left = 0;
        int right = products.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparison = string.Compare(products[mid].ProductName, targetName, true);

            if (comparison == 0)
                return products[mid];
            else if (comparison < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return null;
    }

    static void PrintResult(Product? product)
    {
        if (product != null)
            Console.WriteLine($"Found: {product.ProductName} in category {product.Category}");
        else
            Console.WriteLine("Product not found.");
    }
}
