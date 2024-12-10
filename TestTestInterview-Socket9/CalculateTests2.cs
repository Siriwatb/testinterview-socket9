using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Xunit;
using TestInterview_Socket9;

public class CalculateTests2
{
    [Fact]
    public void SumDynamicProgrammingStyle_SingleLevelItems_ReturnsCorrectSumDynamicProgrammingStyle()
    {
        var Items = new List<Item>
        {
            new Item { Name = "Item1", Amount = 10 },
            new Item { Name = "Item2", Amount = 20 },
            new Item { Name = "Item3", Amount = 30 }
        };
        var memo = new Dictionary<Item, int>();

        int result = Calulate.SumDynamicProgrammingStyle(Items, 0 , memo);

        Assert.Equal(60, result);
    }

    [Fact]
    public void SumDynamicProgrammingStyle_MultiLevelItems_ReturnsCorrectSumDynamicProgrammingStyle()
    {
        var Items = new List<Item>
        {
            new Item { Name = "Item1", Amount = 10, Sub = new List<Item>
                {
                    new Item { Name = "SubItem1", Amount = 5 },
                    new Item { Name = "SubItem2", Amount = 15 }
                }
            },
            new Item { Name = "Item2", Amount = 20 }
        };
        var memo = new Dictionary<Item, int>();

        int result = Calulate.SumDynamicProgrammingStyle(Items, 0 , memo);

        Assert.Equal(50, result);
    }

    [Fact]
    public void SumDynamicProgrammingStyle_EmptyItems_ReturnsZero()
    {
        var Items = new List<Item>();
        var memo = new Dictionary<Item, int>();
        int result = Calulate.SumDynamicProgrammingStyle(Items, 0 , memo);

        Assert.Equal(0, result);
    }

    [Fact]
    public void SumDynamicProgrammingStyle_NullSubItems_ReturnsCorrectSumDynamicProgrammingStyle()
    {
        var Items = new List<Item>
        {
            new Item { Name = "Item1", Amount = 10, Sub = null },
            new Item { Name = "Item2", Amount = 20 }
        };
        
        var memo = new Dictionary<Item, int>();

        int result = Calulate.SumDynamicProgrammingStyle(Items, 0 , memo);

        Assert.Equal(30, result);
    }
    
    [Fact]
    public void SumDynamicProgrammingStyle_DataJSON_ReturnsCorrectSumDynamicProgrammingStyle()
    {
        // Get the base directory of the application
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Combine the base directory with the relative path to the JSON file
        string filePath = Path.Combine(baseDirectory, "data.json");

        // Check if the file exists
        Assert.True(File.Exists(filePath), "JSON file not found.");

        string jsonData = File.ReadAllText(filePath);

        var items = JsonSerializer.Deserialize<List<Item>>(jsonData, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        
        var memo = new Dictionary<Item, int>();
        
        int result = Calulate.SumDynamicProgrammingStyle(items, 0 , memo);

        Assert.Equal(158, result);
    }
    
    [Fact]
    public void SumDynamicProgrammingStyle_DataJSON2_ReturnsCorrectSumDynamicProgrammingStyle()
    {
        // Get the base directory of the application
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Combine the base directory with the relative path to the JSON file
        string filePath = Path.Combine(baseDirectory, "data2.json");

        // Check if the file exists
        Assert.True(File.Exists(filePath), "JSON file not found.");

        string jsonData = File.ReadAllText(filePath);

        var items = JsonSerializer.Deserialize<List<Item>>(jsonData, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        
        var memo = new Dictionary<Item, int>();
        
        int result = Calulate.SumDynamicProgrammingStyle(items, 0 , memo);

        Assert.Equal(5204, result);
    }
    
    [Fact]
    public void SumDynamicProgrammingStyle_DataJSON3_ReturnsCorrectSumDynamicProgrammingStyle()
    {
        // Get the base directory of the application
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Combine the base directory with the relative path to the JSON file
        string filePath = Path.Combine(baseDirectory, "data3.json");

        // Check if the file exists
        Assert.True(File.Exists(filePath), "JSON file not found.");

        string jsonData = File.ReadAllText(filePath);

        var items = JsonSerializer.Deserialize<List<Item>>(jsonData, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        
        var memo = new Dictionary<Item, int>();
        
        int result = Calulate.SumDynamicProgrammingStyle(items, 0 , memo);

        Assert.Equal(255, result);
    }
}