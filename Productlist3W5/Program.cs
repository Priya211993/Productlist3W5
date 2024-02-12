// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main()
    {
        List<string> products = new List<string>();

        Console.WriteLine("Enter product names. Type 'exit' when done.");

        while (true)
        {
            Console.Write("Product: ");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (IsExitCommand(input))
                break;

            if (IsValidProductName(input))
            {
                products.Add(input);
            }
            else
            {
                Console.WriteLine("Invalid product name. Please enter a name consisting of letters, hyphens, and a number between 200 and 500.");
            }
        }

        products.Sort();

        Console.WriteLine("\nSorted Product List (Uppercase):");

        foreach (var product in products)
        {
            Console.WriteLine(product.ToUpper());
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static bool IsExitCommand(string input)
    {
        return input == "exit" || input == "exit " || input == " exit" || input == " exit ";
    }

    static bool IsValidProductName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        // Split the name into parts (letters, hyphens, and numbers)
        string[] parts = name.Split('-', StringSplitOptions.RemoveEmptyEntries);

        // Check each part
        foreach (var part in parts)
        {
            if (!part.All(char.IsLetter) && !int.TryParse(part, out int number))
                return false;

            // If the part is a number, check if it's between 200 and 500
            if (int.TryParse(part, out int num) && (num < 200 || num > 500))
                return false;
        }

        return true;
    }
}
