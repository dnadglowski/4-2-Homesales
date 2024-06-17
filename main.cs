using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    public static void Main (string[] args) {
        Dictionary<string, int> salesData = new Dictionary<string, int>();
        int sum = 0;
        HashSet<string> allowedNames = new HashSet<string> { "e", "d", "f", "E", "D", "F" };

        while(true) {
            Console.WriteLine("Salesperson (type 'z' to stop):");
            var name = Console.ReadLine();
            if(name == "z")
                break;

            if (!allowedNames.Contains(name)) {
                Console.WriteLine("Invalid name entered. Please enter 'e', 'd', or 'f'.");
                continue;
            }

            Console.WriteLine("Sales:");
            if (int.TryParse(Console.ReadLine(), out int sale)) {
                sum += sale;

                if (salesData.ContainsKey(name)) {
                    salesData[name] += sale;
                } else {
                    salesData[name] = sale;
                }
            } else {
                Console.WriteLine("Invalid input for sales. Please enter a valid integer.");
            }
        }


        Console.WriteLine($"Grand Total: {sum}");

        if (salesData.Count > 0) {
            var topSalesperson = salesData.OrderByDescending(kv => kv.Value).First();
            Console.WriteLine($"Top Salesperson: {topSalesperson.Key} with sales of {topSalesperson.Value}");
        }
    }
}
