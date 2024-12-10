using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TestInterview_Socket9;
class Program
{
    static void Main(string[] args)
    {
        // Get the base directory of the application
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        
        // Combine the base directory with the relative path to the JSON file
        string filePath = Path.Combine(baseDirectory, "data.json");
        
        // Check if the file exists
        if (!File.Exists(filePath))
        {
            Console.WriteLine("JSON file not found.");
            return;
        }
        
        string jsonData = File.ReadAllText(filePath);
        
        try
        {
            // Deserialize JSON to a list of Topic objects
            var jsonItemList = JsonSerializer.Deserialize<List<Item>>(jsonData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Makes JSON property matching case-insensitive
            });
        
            // Print the hierarchical data
            if (jsonItemList != null)
            {
                
                // var memo = new Dictionary<Item, int>();
                // int result = Calulate.SumDynamicProgrammingStyle(jsonItemList, 0 , memo);
                
                var result = Calulate.Sum(jsonItemList, 0 );
                Console.WriteLine($"Total amount: {result}");
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error parsing JSON: {ex.Message}");
        }
    }
   
}

public class Item
{
    public string Name { get; set; }
    public int Amount { get; set; }
    public List<Item> Sub { get; set; } = new();
}

public class Calulate
{
    public static int Sum(List<Item> itemList, int level)
    {

        if (itemList.Count == 0)
        {
            return 0;
        }
        
        int totalAmount = 0;
        foreach (var item in itemList)
        {
            // Indent based on the level of nesting
            // Console.WriteLine($"{new string(' ', level * 2)}- Name: {topic.Name}, Amount: {topic.Amount}");
            totalAmount += item.Amount;
            // Recursively print sub-topics and add their amounts
            if (item.Sub != null && item.Sub.Count > 0)
            {
                totalAmount += Sum(item.Sub, level + 1);
            }
        }
        return totalAmount;
    }
    public static int SumDynamicProgrammingStyle(List<Item> itemList, int level, Dictionary<Item, int> memo)
    {
        if (itemList.Count == 0)
        {
            return 0;
        }

        int totalAmount = 0;
        foreach (var item in itemList)
        {
            if (memo.ContainsKey(item))
            {
                totalAmount += memo[item];
            }
            else
            {
                int itemTotal = item.Amount;
                if (item.Sub != null && item.Sub.Count > 0)
                {
                    itemTotal += SumDynamicProgrammingStyle(item.Sub, level + 1, memo);
                }
                memo[item] = itemTotal;
                totalAmount += itemTotal;
            }
        }
        return totalAmount;
    }
}

